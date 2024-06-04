using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Travel.Areas.Identity.Data;
using Travel.Models;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TravelContext _context;
        private readonly UserManager<TravelUser> _userManager;
        private readonly SignInManager<TravelUser> _signInManager;

        public HomeController(
            ILogger<HomeController> logger,
            TravelContext context,
            UserManager<TravelUser> userManager,
            SignInManager<TravelUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var journeys = _context.Journey.ToList();
            var viewModel = new List<ReservationViewModel>();

            foreach (var journey in journeys)
            {
                var attractions = _context.Attraction.Where(a => a.JourneyId == journey.id).ToList();
                viewModel.Add(new ReservationViewModel
                {
                    Journey = journey,
                    Attraction = attractions,
                    User = user // 添加當前登入的使用者資料
                });
            }

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
