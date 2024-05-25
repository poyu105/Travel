using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class JourneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
