using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
