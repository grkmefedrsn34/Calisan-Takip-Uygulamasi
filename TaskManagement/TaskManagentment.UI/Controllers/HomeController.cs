using Microsoft.AspNetCore.Mvc;

namespace TaskManagentment.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
