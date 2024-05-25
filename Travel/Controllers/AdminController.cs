using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Areas.Identity.Data;
using Travel.Models;
using Travel.Models.Entity;

namespace Travel.Controllers
{
    public class AdminController : Controller
    {
        private readonly TravelContext _context;

        public AdminController(TravelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var attractions = _context.Attraction.ToList();
            return View(attractions);
        }

        [HttpGet]
        public IActionResult addAttraction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addAttraction(Attraction view_attraction)
        {
            // 檢查是否有重複的景點名稱
            if(_context.Attraction.Any(a => a.Name == view_attraction.Name))
            {
                ModelState.AddModelError("Name", "景點名稱已存在，請輸入不同的名稱!");
                return View(view_attraction);
            }
            var attraction = new Attraction
            {
                Id = Guid.NewGuid(),
                Name = view_attraction.Name,
                Place = view_attraction.Place,
                Description = view_attraction.Description,
                Type = view_attraction.Type,
                //Picture = view_attraction.Picture
            };

            await _context.Attraction.AddAsync(attraction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Admin");

        }

        [HttpPost]
        public async Task<IActionResult> delAttraction(Guid id)
        {
            var attraction = await _context.Attraction.FindAsync(id);
            if (attraction != null)
            {
                _context.Attraction.Remove(attraction);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
