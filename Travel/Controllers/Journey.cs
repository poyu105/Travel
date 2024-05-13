using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class Journey : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
