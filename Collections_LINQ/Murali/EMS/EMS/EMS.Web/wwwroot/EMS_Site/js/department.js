// department.js
// Single shared script: storage + list UI + modal + standalone Add/Edit page logic.
// All page-specific behavior (including standalone DepartmentEdit.html) is handled here.

(function (window) {
    'use strict';

    const STORAGE_KEY = 'ems_departments_v1';

    // In-memory data
    let departments = [];
    let lastRenderedList = [];

    // Modal references (used on list page)
    let addDeptModalEl = null;
    let addDeptModal = null;

    // --- Storage helpers ---
    function loadFromStorage() {
        const raw = localStorage.getItem(STORAGE_KEY);
        if (raw) {
            try {
                const parsed = JSON.parse(raw);
                if (Array.isArray(parsed)) departments = parsed;
                else departments = [];
            } catch (e) {
                departments = [];
            }
        }

        // Seed sample data when empty
        if (!departments || !departments.length) {
            departments = [
                //{ DepartmentIdPk: 1, DepartmentCode: 'D-001', DepartmentName: 'Human Resources', Location: 'New York', IsActive: true },
                //{ DepartmentIdPk: 2, DepartmentCode: 'D-002', DepartmentName: 'Finance', Location: 'Chicago', IsActive: true },
                //{ DepartmentIdPk: 3, DepartmentCode: 'D-003', DepartmentName: 'Engineering', Location: 'Seattle', IsActive: true }
            ];
            saveToStorage();
        }
    }

    function saveToStorage() {
        localStorage.setItem(STORAGE_KEY, JSON.stringify(departments));
    }

    function getDepartments() {
        return departments.slice();
    }

    function getDepartmentById(id) {
        return departments.find(d => d.DepartmentIdPk === id) || null;
    }

    function getNextId() {
        return departments.length ? Math.max(...departments.map(d => d.DepartmentIdPk)) + 1 : 1;
    }

    // Escape text to avoid HTML injection
    function escapeHtml(text) {
        if (text === null || text === undefined) return '';
        return String(text)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#039;');
    }

    // Generate next DepartmentCode like D-001
    function generateDeptCode() {
        const codes = departments.map(d => d.DepartmentCode).filter(Boolean);
        let max = 0;
        for (const c of codes) {
            const m = c.match(/D0*(\d+)/i); // accept D001 or D-001 etc.
            if (m) {
                const num = parseInt(m[1], 10);
                if (!isNaN(num) && num > max) max = num;
            }
        }
        const nextNum = max + 1;
        return 'D-' + String(nextNum).padStart(3, '0');
    }

    // Data operations
    //function addDepartment({ DepartmentName, Location, IsActive = true }) {
    //    const newDept = {
    //        DepartmentIdPk: getNextId(),
    //        DepartmentCode: generateDeptCode(),
    //        DepartmentName,
    //        Location,
    //        IsActive: !!IsActive
    //    };
    //    departments.push(newDept);
    //    saveToStorage();
    //    return newDept;
    //}

    //function updateDepartment(id, updates) {
    //    const dept = getDepartmentById(id);
    //    if (!dept) return null;
    //    Object.assign(dept, updates);
    //    saveToStorage();
    //    return dept;
    //}

    function deleteDepartment(id) {
        const idx = departments.findIndex(d => d.DepartmentIdPk === id);
        if (idx >= 0) {
            departments.splice(idx, 1);
            saveToStorage();
            return true;
        }
        return false;
    }

    // --- UI: list page & modal ---

    // Render the table from the provided list
    function renderTable(list) {
        const tbody = document.querySelector('#deptTable tbody');
        if (!tbody) return;

        lastRenderedList = list.slice();

        tbody.innerHTML = '';
        if (!list.length) {
            const tr = document.createElement('tr');
            tr.innerHTML = `<td colspan="6" class="text-center text-muted">No departments found.</td>`;
            tbody.appendChild(tr);
            return;
        }

        list.forEach((dept, idx) => {
            const sno = idx + 1;
            const tr = document.createElement('tr');

            // Edit is an anchor to the standalone edit page (passes id in query string).
            const actionsHtml = `
                <a href="/EMS_Site/DepartmentEdit.html?id=${dept.DepartmentIdPk}" class="btn btn-sm btn-primary me-1">Edit</a>
                <button class="btn btn-sm btn-info btn-view me-1" data-id="${dept.DepartmentIdPk}">View</button>
                <button class="btn btn-sm btn-danger btn-delete" data-id="${dept.DepartmentIdPk}">Delete</button>
            `;

            tr.innerHTML = `
                <td>${sno}</td>
                <td>${escapeHtml(dept.DepartmentCode)}</td>
                <td>${escapeHtml(dept.DepartmentName)}</td>
                <td>${escapeHtml(dept.Location)}</td>
                <td>${dept.IsActive ? 'Yes' : 'No'}</td>
                <td>${actionsHtml}</td>
            `;
            tbody.appendChild(tr);
        });

        // Attach handlers for View/Delete (Edit is a normal link)
        tbody.querySelectorAll('.btn-view').forEach(btn => btn.addEventListener('click', onView));
        tbody.querySelectorAll('.btn-delete').forEach(btn => btn.addEventListener('click', onDelete));
    }

    // Search and Clear
    function doSearch() {
        const searchName = document.getElementById('searchName');
        const searchLocation = document.getElementById('searchLocation');
        const nameTerm = searchName ? (searchName.value || '').trim().toLowerCase() : '';
        const locTerm = searchLocation ? (searchLocation.value || '').trim().toLowerCase() : '';

        const filtered = departments.filter(d => {
            const matchesName = !nameTerm || (d.DepartmentName || '').toLowerCase().includes(nameTerm);
            const matchesLoc = !locTerm || (d.Location || '').toLowerCase().includes(locTerm);
            return matchesName && matchesLoc;
        });

        renderTable(filtered);
    }

    function doClear() {
        const searchName = document.getElementById('searchName');
        const searchLocation = document.getElementById('searchLocation');
        if (searchName) searchName.value = '';
        if (searchLocation) searchLocation.value = '';
        renderTable(departments);
    }

    // Compute S.NO relative to the current rendered list
    function computeSerialNo(deptId) {
        const idx = lastRenderedList.findIndex(d => d.DepartmentIdPk === deptId);
        if (idx >= 0) return idx + 1;
        return departments.findIndex(d => d.DepartmentIdPk === deptId) + 1;
    }

    // View - open modal and show readonly details
    function onView(evt) {
        const id = parseInt(evt.currentTarget.getAttribute('data-id'), 10);
        const dept = getDepartmentById(id);
        if (!dept) return;

        const editingIdInput = document.getElementById('editingId');
        const deptNameInput = document.getElementById('deptName');
        const deptLocationInput = document.getElementById('deptLocation');
        const deptIsActiveInput = document.getElementById('deptIsActive');
        const addDeptModalLabel = document.getElementById('addDeptModalLabel');
        const deptSerialNo = document.getElementById('deptSerialNo');

        if (editingIdInput) editingIdInput.value = dept.DepartmentIdPk;
        if (deptNameInput) { deptNameInput.value = dept.DepartmentName; deptNameInput.setAttribute('readonly', 'readonly'); }
        if (deptLocationInput) { deptLocationInput.value = dept.Location; deptLocationInput.setAttribute('readonly', 'readonly'); }
        if (deptIsActiveInput) { deptIsActiveInput.checked = !!dept.IsActive; deptIsActiveInput.setAttribute('disabled', 'disabled'); }
        if (addDeptModalLabel) addDeptModalLabel.textContent = 'View Department';
        if (deptSerialNo) deptSerialNo.textContent = computeSerialNo(dept.DepartmentIdPk);

        const btnSaveDept = document.getElementById('btnSaveDept');
        if (btnSaveDept) btnSaveDept.style.display = 'none';

        if (addDeptModal) addDeptModal.show();

        // restore editable state when modal closes
        if (addDeptModalEl) {
            addDeptModalEl.addEventListener('hidden.bs.modal', function onHidden() {
                const bn = document.getElementById('deptName');
                const bl = document.getElementById('deptLocation');
                const bi = document.getElementById('deptIsActive');
                const bs = document.getElementById('btnSaveDept');
                if (bn) bn.removeAttribute('readonly');
                if (bl) bl.removeAttribute('readonly');
                if (bi) bi.removeAttribute('disabled');
                if (bs) bs.style.display = '';
            }, { once: true });
        }
    }

    // Delete handler
    function onDelete(evt) {
        const id = parseInt(evt.currentTarget.getAttribute('data-id'), 10);
        const dept = getDepartmentById(id);
        if (!dept) return;
        if (confirm(`Delete department "${dept.DepartmentName}"?`)) {
            deleteDepartment(id);
            renderTable(departments);
        }
    }

    // Save handler for modal (edit/save)
    function onSave(event) {
        event.preventDefault();
        const editingIdInput = document.getElementById('editingId');
        const deptNameInput = document.getElementById('deptName');
        const deptLocationInput = document.getElementById('deptLocation');
        const deptIsActiveInput = document.getElementById('deptIsActive');

        const name = deptNameInput ? (deptNameInput.value || '').trim() : '';
        const location = deptLocationInput ? (deptLocationInput.value || '').trim() : '';
        const isActive = deptIsActiveInput ? !!deptIsActiveInput.checked : true;

        if (!name || !location) {
            alert('Please fill Department Name and Location.');
            return;
        }

        if (editingIdInput && editingIdInput.value) {
            const id = parseInt(editingIdInput.value, 10);
            updateDepartment(id, { DepartmentName: name, Location: location, IsActive: isActive });
        } else {
            // Fallback: add from modal (list page add should redirect to standalone)
            addDepartment({ DepartmentName: name, Location: location, IsActive: isActive });
        }

        if (addDeptModal) addDeptModal.hide();
        renderTable(departments);
    }

    // Menu toggle helper
    function initMenuToggle() {
        const btnToggle = document.getElementById('btnToggleMenu');
        const sideMenu = document.getElementById('sideMenu');
        if (btnToggle && sideMenu) {
            btnToggle.addEventListener('click', () => {
                sideMenu.classList.toggle('collapsed');
            });
        }
    }

    // Initialize list page (table + modal)
    function initListPage() {
        const tableElement = document.getElementById('deptTable');
        if (!tableElement) return;

        // Wire search / clear
        const btnSearch = document.getElementById('btnSearch');
        if (btnSearch) btnSearch.addEventListener('click', doSearch);

        const btnClear = document.getElementById('btnClear');
        if (btnClear) btnClear.addEventListener('click', doClear);

        // Add button: if it's a button element (not anchor), navigate programmatically
        const btnAddDept = document.getElementById('btnAddDept');
        if (btnAddDept && btnAddDept.tagName && btnAddDept.tagName.toLowerCase() === 'button') {
            btnAddDept.addEventListener('click', () => window.location.href = '/EMS_Site/DepartmentEdit.html');
        }

        // Modal setup (modal form uses id 'deptForm' inside the modal)
        addDeptModalEl = document.getElementById('addDeptModal');
        if (addDeptModalEl) {
            addDeptModal = new bootstrap.Modal(addDeptModalEl);
            const modalForm = addDeptModalEl.querySelector('form') || document.getElementById('deptForm');
            if (modalForm) modalForm.addEventListener('submit', onSave);
        }

        initMenuToggle();

        renderTable(departments);
    }

    // Initialize standalone Add/Edit page (DepartmentEdit.html)
    function initStandaloneAddEditPage() {
        // detect standalone page: no table and no modal
        const isStandalone = !document.getElementById('deptTable') && !document.getElementById('addDeptModal');
        if (!isStandalone) return;

        const addForm = document.getElementById('addDeptForm') || document.getElementById('deptForm');
        if (!addForm) return;

        const nameInput = document.getElementById('deptName');
        const locationInput = document.getElementById('deptLocation');
        const editingIdEl = document.getElementById('editingId');
        const isActiveContainer = document.getElementById('isActiveContainer');
        const isActiveInput = document.getElementById('deptIsActive');
        const pageTitle = document.getElementById('pageTitle');
        const cardTitle = document.getElementById('cardTitle');
        const cardHelp = document.getElementById('cardHelp');

        // Determine edit mode by query string id
        const params = new URLSearchParams(window.location.search);
        const idParam = params.get('id');
        const isEditMode = !!idParam;

        if (isEditMode) {
            const id = parseInt(idParam, 10);
            const dept = getDepartmentById(id);
            if (!dept) {
                alert('Department not found.');
                window.location.href = '/EMS_Site/DepartmentsList.html';
                return;
            }

            // populate fields
            if (pageTitle) pageTitle.textContent = 'Edit Department';
            if (cardTitle) cardTitle.textContent = 'Edit Department';
            if (cardHelp) cardHelp.textContent = 'Modify details and save.';
            if (editingIdEl) editingIdEl.value = dept.DepartmentIdPk;
            if (nameInput) nameInput.value = dept.DepartmentName || '';
            if (locationInput) locationInput.value = dept.Location || '';
            if (isActiveContainer) isActiveContainer.style.display = '';
            if (isActiveInput) isActiveInput.checked = !!dept.IsActive;
        } else {
            // Add mode
            if (pageTitle) pageTitle.textContent = 'Edit Department';
            if (cardTitle) cardTitle.textContent = 'Edit Department';
            if (cardHelp) cardHelp.textContent = 'Enter department details. New departments are Active by default.';
            if (editingIdEl) editingIdEl.value = '';
            if (isActiveContainer) isActiveContainer.style.display = 'none';
            if (isActiveInput) isActiveInput.checked = true;
        }

        // Submit handler for standalone page
        addForm.addEventListener('submit', function (e) {
            e.preventDefault();

            const name = nameInput ? (nameInput.value || '').trim() : '';
            const location = locationInput ? (locationInput.value || '').trim() : '';

            if (!name || !location) {
                alert('Please fill Department Name and Location.');
                return;
            }

            if (isEditMode && editingIdEl && editingIdEl.value) {
                const id = parseInt(editingIdEl.value, 10);
                const isActive = isActiveInput ? !!isActiveInput.checked : true;
                updateDepartment(id, { DepartmentName: name, Location: location, IsActive: isActive });
            } else {
                // Add: IsActive defaults to true (we do not show the input on Add page)
                addDepartment({ DepartmentName: name, Location: location, IsActive: true });
            }

            // Redirect back to list after save
            window.location.href = '/EMS_Site/DepartmentsList.html';
        });

        initMenuToggle();
    }

    // Initialize on DOMContentLoaded
    document.addEventListener('DOMContentLoaded', function () {
        loadFromStorage();
        initListPage();
        initStandaloneAddEditPage();
    });

    // Expose DepartmentApp API (optional)
    window.DepartmentApp = {
        loadFromStorage,
        saveToStorage,
        getDepartments,
        getDepartmentById,
        addDepartment,
        updateDepartment,
        deleteDepartment,
        generateDeptCode
    };

})(window);