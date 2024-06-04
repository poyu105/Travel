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

            // 檢查是否有重複的景點名稱，除了當前的景點名稱
            if (_context.Journey.Any(a => a.place == view_journey.place && a.id != view_journey.id))
            {
                ModelState.AddModelError("place", "行程名稱已存在，請輸入不同的名稱!");
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
            // Pass the new Journey ID to the addAttraction action
            return RedirectToAction("addAttraction", "Admin", new { journeyId = journey.id });
        }
        [HttpGet]
        public async Task<IActionResult> editJourney(int journeyID)
        {
            var journey = await _context.Journey.FindAsync(journeyID);
            return View(journey);
        }
        [HttpPost]
        public async Task<IActionResult> editJourney(Journey view_journey)
        {
            if(!ModelState.IsValid)
            {
                return View(view_journey);
            }
            var journey = await _context.Journey.FindAsync(view_journey.id);
            if (journey != null)
            {
                journey.place = view_journey.place;
                journey.start_date=view_journey.start_date;
                journey.end_date=view_journey.end_date;

                _context.Journey.Update(journey);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("editAttraction", "Admin", new { journeyId = view_journey.id});
        }
        [HttpGet]
        public async Task<IActionResult> delJourney(int id)
        {
            var journey = await _context.Journey.FindAsync(id);
            if (journey != null)
            {
                _context.Journey.Remove(journey);
                await _context.SaveChangesAsync();
            }
                return RedirectToAction("index", "Admin");
        }
    }
}
