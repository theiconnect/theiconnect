namespace Invoice.Web.Models
{
    public class InvoiceModels
    {
        public int InvoiceId { get; set; }
        public string InvoiceCode { get; set; }
        public string InvoiceName { get; set; }
        public int CountryId { get; set; }
        public decimal Price { get; set; }
        public decimal? Duty { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Description { get; set; }
    }
}

