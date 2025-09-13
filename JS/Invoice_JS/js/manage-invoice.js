window.addEventListener("DOMContentLoaded", function () {

    let txtInvoiceCode = document.getElementById("InvoiceCode");

    let nextInvoiceCode = getNextinvoicecode()
    txtInvoiceCode.value = nextInvoiceCode;

    txtInvoiceCode.setAttribute("readonly");

});

function getNextinvoicecode() {
    //Get All the invoices from Local storage
    let myInvoices = localStorage.getItem('myInvoices')
    //Check whether any invoices present
    if (!myInvoices) {
        //There is no invoices available so we can assume this is the first inovices so directly return INV-001 should work.
        return 'INV-001'
    }
    else {
        //TODO:: 
        //================================================================
        //We have some inovices already avilable in Local Storage
        //Note: Local Storage will always store the data in string format.
        //which means if get invoices, that will be in string so we need to convert the string(Json) to objects
        //Now we have array of invoices
        //loop through all invoices -> get invoice code -> get the number from invoice code
        //find out max invoice code(number)
        //increase it by 1
        //then you will get another number for example: max invoice number is 5 then you will get 6
        //frame or build the invoice code string by adding INV- BEFORE THE NUMBER.
        //================================================================
    }
}
