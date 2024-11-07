using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
