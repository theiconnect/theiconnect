(() => {
    const form = document.getElementById('invoiceForm');
    const priceEl = document.getElementById('price');
    const dutyEl = document.getElementById('duty');
    const totalEl = document.getElementById('totalPrice');
    const btnRefresh = document.getElementById('btnRefresh');
    const btnBack = document.getElementById('btnBack');
    const alertPlaceholder = document.getElementById('alertPlaceholder');

    function showAlert(message, type = 'success', timeout = 3500) {
        alertPlaceholder.innerHTML = '';
        const wrapper = document.createElement('div');
        wrapper.innerHTML = `
      <div class="alert alert-${type} alert-dismissible fade show" role="alert">
        ${escapeHtml(message)}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
      </div>`;
        alertPlaceholder.appendChild(wrapper);
        if (timeout) setTimeout(() => wrapper.remove(), timeout);
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

    function computeTotal() {
        const p = Number(priceEl.value) || 0;
        const d = Number(dutyEl.value) || 0;
        const total = p + d;
        totalEl.value = total.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });
    }

    // events
    priceEl.addEventListener('input', computeTotal);
    dutyEl.addEventListener('input', computeTotal);

    btnRefresh.addEventListener('click', () => {
        form.reset();
        totalEl.value = '';
        form.classList.remove('was-validated');
        alertPlaceholder.innerHTML = '';
    });

    btnBack.addEventListener('click', () => {
        if (document.referrer) window.history.back();
        else window.location.href = '/js/Invoice_site/InvoiceList.html';
    });

    form.addEventListener('submit', async (e) => {
        e.preventDefault();
        form.classList.add('was-validated');
        if (!form.checkValidity()) {
            showAlert('Please fix validation errors before saving.', 'warning', 3000);
            return;
        }

        const payload = {
            code: document.getElementById('invoiceCode').value.trim(),
            name: document.getElementById('invoiceName').value.trim(),
            country: document.getElementById('country').value,
            price: Number(priceEl.value) || 0,
            duty: Number(dutyEl.value) || 0,
            total: (Number(priceEl.value) || 0) + (Number(dutyEl.value) || 0),
            manufacturedDate: document.getElementById('manufacturedDate').value || null,
            expiryDate: document.getElementById('expiryDate').value || null,
            description: document.getElementById('description').value.trim()
        };

        try {
            const res = await fetch('/api/invoices', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload)
            });
            if (!res.ok) throw new Error(`Server returned ${res.status}`);
            showAlert('Invoice saved successfully.', 'success');
            setTimeout(() => window.location.href = '/js/Invoice_site/InvoiceList.html', 800);
        } catch (err) {
            // fallback: save to localStorage so UI works without server
            try {
                const existing = JSON.parse(localStorage.getItem('invoices') || '[]');
                payload.id = Date.now();
                existing.push(payload);
                localStorage.setItem('invoices', JSON.stringify(existing));
                showAlert('Saved locally (no API). Redirecting to list...', 'info');
                setTimeout(() => window.location.href = '/js/Invoice_site/InvoiceList.html', 900);
            } catch (ex) {
                showAlert('Failed to save invoice: ' + ex.message, 'danger', 6000);
                console.error(ex);
            }
        }
    });

    // initial compute in case price/duty were prefilled
    computeTotal();
})();
  
