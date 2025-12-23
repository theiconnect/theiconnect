(() => {
    const state = {
        invoices: [],
        filtered: [],
        page: 1,
        pageSize: 10
    };
     
    // Sample data fallback — replace /api fetch with your real endpoint
    const sampleData = [
        { id: 1, code: 'INV-001', name: 'Widget A', country: 'USA', price: 100.00, duty: 5.00, manufacturedDate: '2024-01-02', expiryDate: '2026-01-01' },
        { id: 2, code: 'INV-002', name: 'Widget B', country: 'Canada', price: 250.00, duty: 12.50, manufacturedDate: '2024-03-12', expiryDate: '2027-03-11' },
        { id: 3, code: 'INV-003', name: 'Gadget X', country: 'UK', price: 75.50, duty: 3.78, manufacturedDate: '2023-11-30', expiryDate: '2025-11-30' }
    ];

    // DOM refs
    const tbody = document.getElementById('tblInvoice-body');
    const txtSearch = document.getElementById('txtSearch');
    const pageSizeSelect = document.getElementById('pageSize');
    const pager = document.getElementById('pager');
    const summary = document.getElementById('summary');

    async function fetchInvoices() {
        try {
            const res = await fetch('/api/invoices', { method: 'GET' });
            if (!res.ok) throw new Error('API returned error');
            const data = await res.json();
            state.invoices = Array.isArray(data) ? data : [];
        } catch (e) {
            // Fallback to sample data
            console.warn('Falling back to sample invoices:', e.message);
            state.invoices = sampleData;
        }
        applyFilter();
    }

    function applyFilter() {
        const q = (txtSearch.value || '').trim().toLowerCase();
        state.filtered = state.invoices.filter(inv => {
            if (!q) return true;
            return (inv.code || '').toLowerCase().includes(q)
                || (inv.name || '').toLowerCase().includes(q)
                || (inv.country || '').toLowerCase().includes(q);
        });
        state.page = 1;
        render();
    }

    function render() {
        const total = state.filtered.length;
        const pageSize = state.pageSize;
        const page = Math.max(1, Math.min(state.page, Math.ceil(Math.max(1, total) / pageSize)));
        const start = (page - 1) * pageSize;
        const pageItems = state.filtered.slice(start, start + pageSize);

        tbody.innerHTML = '';
        if (pageItems.length === 0) {
            const tr = document.createElement('tr');
            tr.innerHTML = `<td colspan="9" class="text-center">No invoices found</td>`;
            tbody.appendChild(tr);
        } else {
            for (const inv of pageItems) {
                const tr = document.createElement('tr');
                const totalPrice = (Number(inv.price) || 0) + (Number(inv.duty) || 0);

                tr.innerHTML = `
                    <td>${escapeHtml(inv.code)}</td>
                    <td>${escapeHtml(inv.name)}</td>
                    <td>${escapeHtml(inv.country)}</td>
                    <td class="text-end">${formatCurrency(inv.price)}</td>
                    <td class="text-end">${formatCurrency(inv.duty)}</td>
                    <td class="text-end">${formatCurrency(totalPrice)}</td>
                    <td>${formatDate(inv.manufacturedDate)}</td>
                    <td>${formatDate(inv.expiryDate)}</td>
                    <td class="text-center">
                        <a class="btn btn-sm btn-outline-primary action-btn" data-action="view" data-id="${inv.id}">View</a>
                        <a class="btn btn-sm btn-outline-secondary action-btn" data-action="edit" data-id="${inv.id}">Edit</a>
                        <button class="btn btn-sm btn-outline-danger action-btn" data-action="delete" data-id="${inv.id}">Delete</button>
                    </td>
                `;
                tbody.appendChild(tr);
            }
        }

        renderPager(total, page, pageSize);
        summary.textContent = `Showing ${Math.min(total, start + 1)}–${Math.min(total, start + pageItems.length)} of ${total}`;
    }

    function renderPager(total, page, pageSize) {
        pager.innerHTML = '';
        const pageCount = Math.max(1, Math.ceil(total / pageSize));
        const makeLi = (label, p, disabled = false, active = false) => {
            const li = document.createElement('li');
            li.className = 'page-item' + (disabled ? ' disabled' : '') + (active ? ' active' : '');
            const a = document.createElement('a');
            a.className = 'page-link';
            a.href = '#';
            a.dataset.page = p;
            a.textContent = label;
            li.appendChild(a);
            return li;
        };

        pager.appendChild(makeLi('«', 1, page === 1));
        for (let i = 1; i <= pageCount; i++) {
            pager.appendChild(makeLi(i, i, false, i === page));
        }
        pager.appendChild(makeLi('»', pageCount, page === pageCount));
    }

    // Events
    txtSearch.addEventListener('input', debounce(applyFilter, 250));
    pageSizeSelect.addEventListener('change', () => {
        state.pageSize = parseInt(pageSizeSelect.value, 10) || 10;
        state.page = 1;
        render();
    });

    pager.addEventListener('click', (e) => {
        e.preventDefault();
        const a = e.target.closest('a');
        if (!a) return;
        const p = parseInt(a.dataset.page, 10);
        if (isNaN(p)) return;
        state.page = p;
        render();
    });

    // Delegate actions
    tbody.addEventListener('click', async (e) => {
        const btn = e.target.closest('[data-action]');
        if (!btn) return;
        const action = btn.dataset.action;
        const id = btn.dataset.id;
        if (action === 'view') {
            // navigate to view page with id
            window.location.href = `./InvoiceView.html?id=${encodeURIComponent(id)}`;
        } else if (action === 'edit') {
            window.location.href = `./InvoiceEdit.html?id=${encodeURIComponent(id)}`;
        } else if (action === 'delete') {
            if (!confirm('Delete this invoice? This action cannot be undone.')) return;
            await deleteInvoice(id);
        }
    });

    async function deleteInvoice(id) {
        try {
            const res = await fetch(`/api/invoices/${encodeURIComponent(id)}`, { method: 'DELETE' });
            if (res.ok) {
                // remove from local state
                state.invoices = state.invoices.filter(i => String(i.id) !== String(id));
                applyFilter();
            } else {
                throw new Error('Delete failed');
            }
        } catch (e) {
            alert('Unable to delete invoice. (If you don\'t have an API, this demo will delete only in memory.)');
            // fallback: delete in-memory
            state.invoices = state.invoices.filter(i => String(i.id) !== String(id));
            applyFilter();
        }
    }

    // Utilities
    function formatCurrency(v) {
        const n = Number(v) || 0;
        return n.toLocaleString(undefined, { style: 'currency', currency: 'USD', minimumFractionDigits: 2 });
    }

    function formatDate(d) {
        if (!d) return '';
        const dt = new Date(d);
        if (Number.isNaN(dt.getTime())) return escapeHtml(d);
        return dt.toLocaleDateString();
    }

    function escapeHtml(s) {
        if (s === null || s === undefined) return '';
        return String(s)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    function debounce(fn, wait) {
        let t;
        return (...args) => {
            clearTimeout(t);
            t = setTimeout(() => fn.apply(this, args), wait);
        };
    }

    // Boot
    document.addEventListener('DOMContentLoaded', () => {
        // If you want to seed from server-rendered JSON, you can set window.__INVOICES__ before this script runs.
        if (Array.isArray(window.__INVOICES__) && window.__INVOICES__.length) {
            state.invoices = window.__INVOICES__;
            applyFilter();
        } else {
            fetchInvoices();
        }
    });
})();