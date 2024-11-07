using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
