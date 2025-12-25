
using EMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class ScopedDemoController : Controller
    {
        /*private readonly CompanyService _serviceFromCtor;

        public ScopedDemoController(CompanyService service)
        {
            _serviceFromCtor = service;
        }

        // GET: /ScopedDemo/Index
        public IActionResult Index([FromServices] CompanyService serviceFromAction)
        {
            // Both _serviceFromCtor and serviceFromAction should be the same instance for this request
            bool sameInstance = ReferenceEquals(_serviceFromCtor, serviceFromAction);

            // Demonstrate with a unique property (e.g., hash code)
            int ctorHash = _serviceFromCtor.GetHashCode();
            int actionHash = serviceFromAction.GetHashCode();

            // Optionally, increment a property to show state is shared
            _serviceFromCtor.x++;
            int xValue = _serviceFromCtor.x;

            var result = new
            {
                SameInstance = sameInstance,
                CtorHash = ctorHash,
                ActionHash = actionHash,
                XValue = xValue
            };

            // Return as JSON for easy inspection
            return Json(result);
        }
        */
    }
}
