using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
