using Microsoft.AspNetCore.Mvc;

namespace BuildUCPU.Controllers
{
    public class CompatibilityController : Controller
    {
        public IActionResult Index(string data)
        {
            // Przekaż dane do widoku
            ViewBag.SelectedComponents = data?.Split(',') ?? new string[0]; // Przekazuje jako tablicę
            return View();
        }
    }
}
