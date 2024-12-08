using Microsoft.AspNetCore.Mvc;

namespace BuildUCPU.Controllers.Footer
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
