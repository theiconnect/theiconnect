using Microsoft.AspNetCore.Mvc;

namespace Invoice.Web.Controllers
{
    [Route("Controller")]
    public class InvoiceController : Controller
    {
        [Route("list")]
        [Route("listall")]

        public IActionResult List()
        {
            return View();
        }

        public IActionResult InvoiceAdd()
        {
            return View();
        }

        public IActionResult InvoiceEdit(int id)
        {
            return View();
        }

        public IActionResult InvoiceView(int id)
        {
            return View();
        }
    }
}
