using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Travel.Areas.Identity.Data;
using Travel.Models;
using Travel.Models.Entity;

namespace Travel.Controllers
{
    public class JourneyController : Controller
    {

        private readonly TravelContext _context;

        public JourneyController(TravelContext mvcDBContext)
        {
            _context = mvcDBContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var journey = _context.Journey.ToList();
            return View(journey);
        }
        [HttpGet]
        public IActionResult addJourney()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addJourney(Journey view_journey)
        {
            if (!ModelState.IsValid)
            {
                return View(view_journey);
            }
            var journey = new Journey
            {
                place = view_journey.place,
                start_date = view_journey.start_date,
                end_date = view_journey.end_date,
            };

            await _context.Journey.AddAsync(journey);
            await _context.SaveChangesAsync();
            return RedirectToAction("addAttraction","Admin");
        }
        [HttpPatch]
        public async Task<IActionResult> editJourney(Journey view_journey)
        {
            // 檢查是否輸入資料
            if (!ModelState.IsValid)
            {
                return View(view_journey);
            }

            var journey = await _context.Journey.FindAsync(view_journey.id);
            if (journey != null)
            {
                journey.place = view_journey.place;
                journey.start_date = view_journey.start_date;
                journey.end_date = view_journey.end_date;

                _context.Journey.Update(journey);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("showJourney", "Admin");
        }
        [HttpPost]
        public async Task<IActionResult> deleteJourney(Guid id)
        {
            var journey = await _context.Journey.FindAsync(id);
            if (journey != null)
            {
                _context.Journey.Remove(journey);
                await _context.SaveChangesAsync();
            }
                return RedirectToAction("showJourney", "Admin");
        }
    }
}
