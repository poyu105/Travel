using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class Reservation : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
