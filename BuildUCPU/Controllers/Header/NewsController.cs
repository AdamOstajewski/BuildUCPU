using Microsoft.AspNetCore.Mvc;

namespace BuildUCPU.Controllers.Header
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
