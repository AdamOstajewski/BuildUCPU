using Microsoft.AspNetCore.Mvc;

namespace BuildUCPU.Controllers.Footer
{
    public class TermsOfServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
