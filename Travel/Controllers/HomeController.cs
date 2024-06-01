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

        public HomeController(ILogger<HomeController> logger, TravelContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var journeys = _context.Journey.ToList();
            var viewModel = new List<JourneyAttractionViewModel>();

            foreach (var journey in journeys)
            {
                var attractions = _context.Attraction.Where(a => a.Journey_id == journey.id).ToList();
                viewModel.Add(new JourneyAttractionViewModel
                {
                    Journey = journey,
                    Attraction = attractions
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
