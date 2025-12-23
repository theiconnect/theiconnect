window.onload = function () {

    let price = 38.0;
    let duty = 48.0;
    let total = price + duty;

    document.getElementById("invoiceCode").innerText = "INV-001";
    document.getElementById("country").innerText = "China";
    document.getElementById("price").innerText = price;
    document.getElementById("duty").innerText = duty;
    document.getElementById("total").innerText = total;

    document.getElementById("invoiceName").innerText = "Venkey";
    document.getElementById("manufacturedDate").innerText = "31/10/2025";
    document.getElementById("expiryDate").innerText = "31/11/2025";
    document.getElementById("description").innerText = "Invoice Description Sample";
};

function saveInvoice() {
    alert("Invoice Saved Successfully!");
}

function refreshPage() {
    location.reload();
}

function goBack() {
    window.history.back();
}
