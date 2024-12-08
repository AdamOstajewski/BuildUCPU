using Microsoft.AspNetCore.Mvc;

namespace BuildUCPU.Controllers.Header
{
    public class PoradyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
