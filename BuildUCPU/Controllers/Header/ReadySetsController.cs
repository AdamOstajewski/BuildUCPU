using Microsoft.AspNetCore.Mvc;

namespace BuildUCPU.Controllers.Header
{
    public class ReadySetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
