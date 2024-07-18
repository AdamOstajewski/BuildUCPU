using Microsoft.AspNetCore.Mvc;

namespace BuildUCPU.Controllers.Header
{
    public class ComponentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
