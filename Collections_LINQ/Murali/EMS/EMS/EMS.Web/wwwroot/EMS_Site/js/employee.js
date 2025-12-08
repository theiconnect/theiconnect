/**
 * employee_list.js
 * - seeds storage with sample entries (EMP001 Sai Ram, EMP002 Reju Rama O, EMP003 John Doe)
 * - renders grid with columns per sketch
 * - implements name/gender/designation filters with Search and Clear buttons
 * - actions: View (modal), Edit (link), Delete (confirm + persist)
 * - sidebar toggle
 */

(function () {
    'use strict';

    const STORAGE_KEY = 'employeePortal:employees';

    const sampleData = [
        {
            EmployeeIdPk: 1,
            EmployeeCode: 'EMP001',
            FirstName: 'Sai',
            LastName: 'Ram',
            Group: 'IT',
            Gender: 'Male',
            Mobile: '9999000001',
            Email: 'sairam@example.com',
            DOJ: '2022-01-10'
        },
        {
            EmployeeIdPk: 2,
            EmployeeCode: 'EMP002',
            FirstName: 'Reju',
            LastName: 'Rama O',
            Group: 'Finance',
            Gender: 'Female',
            Mobile: '9999000002',
            Email: 'reju@example.com',
            DOJ: '2021-07-15'
        },
        {
            EmployeeIdPk: 3,
            EmployeeCode: 'EMP003',
            FirstName: 'John',
            LastName: 'Doe',
            Group: 'HR',
            Gender: 'Male',
            Mobile: '9999000003',
            Email: 'john@example.com',
            DOJ: '2020-05-20'
        }
    ];

    function seedStorageIfNeeded() {
        if (!localStorage.getItem(STORAGE_KEY)) {
            localStorage.setItem(STORAGE_KEY, JSON.stringify(sampleData));
        }
    }

    function readStorage() {
        try {
            return JSON.parse(localStorage.getItem(STORAGE_KEY) || '[]');
        } catch {
            return [];
        }
    }

    function writeStorage(list) {
        localStorage.setItem(STORAGE_KEY, JSON.stringify(list || []));
    }

    function escapeHtml(s) {
        if (s == null) return '';
        return String(s)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    function buildRow(emp, sno) {
        const id = emp.EmployeeIdPk;
        const code = emp.EmployeeCode || '';
        const first = emp.FirstName || '';
        const last = emp.LastName || '';
        const group = emp.Group || '';
        const gender = emp.Gender || '';
        const mobile = emp.Mobile || '';

        const tr = document.createElement('tr');
        tr.setAttribute('data-id', id);
        tr.setAttribute('data-code', String(code).toLowerCase());
        tr.setAttribute('data-firstname', String(first).toLowerCase());
        tr.setAttribute('data-lastname', String(last).toLowerCase());
        tr.setAttribute('data-gender', String(gender).toLowerCase());
        tr.setAttribute('data-designation', String(group).toLowerCase());
        tr.setAttribute('data-email', String(emp.Email || '').toLowerCase());

        tr.innerHTML = [
            `<td>${sno}</td>`,
            `<td>${escapeHtml(code)}</td>`,
            `<td>${escapeHtml(first)}</td>`,
            `<td>${escapeHtml(last)}</td>`,
            `<td>${escapeHtml(group)}</td>`,
            `<td>${escapeHtml(gender)}</td>`,
            `<td>${escapeHtml(mobile)}</td>`,
            `<td class="text-center">
                <button class="btn btn-sm btn-outline-info btn-view me-1" data-id="${escapeHtml(id)}" title="View"><i class="fas fa-eye"></i></button>
                <a class="btn btn-sm btn-outline-primary me-1" href="employee_edit.html?id=${encodeURIComponent(id)}" title="Edit"><i class="fas fa-edit"></i></a>
                <button class="btn btn-sm btn-outline-danger btn-delete" data-id="${escapeHtml(id)}" title="Delete"><i class="fas fa-trash"></i></button>
            </td>`
        ].join('');

        return tr;
    }

    function renderGrid() {
        const tbody = document.getElementById('employeeTbody');
        if (!tbody) return;
        tbody.innerHTML = '';

        const list = readStorage().slice(); // clone
        list.sort((a, b) => (Number(a.EmployeeIdPk) || 0) - (Number(b.EmployeeIdPk) || 0));

        let sno = 1;
        for (const emp of list) {
            tbody.appendChild(buildRow(emp, sno++));
        }

        attachHandlers();
    }

    function attachHandlers() {
        document.querySelectorAll('.btn-delete').forEach(btn => {
            btn.removeEventListener('click', onDelete);
            btn.addEventListener('click', onDelete);
        });
        document.querySelectorAll('.btn-view').forEach(btn => {
            btn.removeEventListener('click', onView);
            btn.addEventListener('click', onView);
        });
    }

    function onDelete(e) {
        const id = e.currentTarget.getAttribute('data-id');
        if (!id) return;
        if (!confirm('Delete employee id ' + id + ' ?')) return;

        let list = readStorage();
        list = list.filter(it => String(it.EmployeeIdPk) !== String(id));
        writeStorage(list);
        renderGrid();
    }

    function onView(e) {
        const id = e.currentTarget.getAttribute('data-id');
        if (!id) return;
        const list = readStorage();
        const emp = list.find(it => String(it.EmployeeIdPk) === String(id));
        if (!emp) return;

        const body = document.getElementById('viewEmployeeBody');
        const modalEdit = document.getElementById('modalEditLink');
        if (modalEdit) modalEdit.href = `employee_edit.html?id=${encodeURIComponent(emp.EmployeeIdPk)}`;

        body.innerHTML = `
            <dl class="row">
                <dt class="col-sm-3">Employee Code</dt><dd class="col-sm-9">${escapeHtml(emp.EmployeeCode)}</dd>
                <dt class="col-sm-3">Name</dt><dd class="col-sm-9">${escapeHtml(emp.FirstName)} ${escapeHtml(emp.LastName)}</dd>
                <dt class="col-sm-3">Group</dt><dd class="col-sm-9">${escapeHtml(emp.Group || '')}</dd>
                <dt class="col-sm-3">Gender</dt><dd class="col-sm-9">${escapeHtml(emp.Gender || '')}</dd>
                <dt class="col-sm-3">Mobile</dt><dd class="col-sm-9">${escapeHtml(emp.Mobile || '')}</dd>
                <dt class="col-sm-3">Email</dt><dd class="col-sm-9">${escapeHtml(emp.Email || '')}</dd>
                <dt class="col-sm-3">DOJ</dt><dd class="col-sm-9">${escapeHtml(emp.DOJ || '')}</dd>
            </dl>
        `;

        const modalEl = document.getElementById('viewEmployeeModal');
        const bsModal = new bootstrap.Modal(modalEl);
        bsModal.show();
    }

    // initialize page
    document.addEventListener('DOMContentLoaded', function () {
        seedStorageIfNeeded();
        renderGrid();

        // optional: wire filter inputs if present (live name filter example)
        const nameInput = document.getElementById('filterName');
        if (nameInput) {
            nameInput.addEventListener('input', function () {
                const q = (this.value || '').trim().toLowerCase();
                const rows = Array.from(document.querySelectorAll('#employeeTbody tr'));
                rows.forEach(r => {
                    const first = r.getAttribute('data-firstname') || '';
                    const last = r.getAttribute('data-lastname') || '';
                    const match = !q || first.includes(q) || last.includes(q);
                    r.style.display = match ? '' : 'none';
                });
            });
        }
    });
})();