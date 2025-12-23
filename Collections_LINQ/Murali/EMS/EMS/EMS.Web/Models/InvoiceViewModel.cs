using System.ComponentModel.DataAnnotations;

namespace EMS.Web.Models
{
    public class InvoiceViewModel
    {
        [Required(ErrorMessage = "The InvoiceName field is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "InvoiceName Length should be min 3 and max 100")]
        [Display(Name = "Invoice Name")]
        public string InvoiceName { get; set; }



        [Required(ErrorMessage = "The InvoiceCode field is required.")]
        [Display(Name = "Invoice Code")]
        public string InvoiceCode { get; set; }


        [Required(ErrorMessage = "The InvoiceDate field is required.")]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "The Amount field is required.")]
        [Range(18, 100, ErrorMessage = "Amount must be at least 18 and max 100.")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }


        [Display(Name = "Is Paid")]
        public bool IsPaid { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Invalid email address.")]
        [Display(Name = "Customer Email")]
        public string Email { get; set; }
    }
}
