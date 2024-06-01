using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Travel.Areas.Identity.Data;
using Travel.Models;
using Travel.Models.Entity;
using Travel.ViewModels;

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
            var journey = _context.Journey.ToList();
            return View(journey);
        }

        [HttpGet]
        public IActionResult addAttraction()
        {
            var viewModel = new AttractionListViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttraction(AttractionListViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            foreach (var attraction in viewModel.Attractions)
            {
                if (string.IsNullOrWhiteSpace(attraction.Name) || string.IsNullOrWhiteSpace(attraction.Description))
                {
                    continue;
                }

                if (_context.Attraction.Any(a => a.Name == attraction.Name))
                {
                    ModelState.AddModelError("Attractions.Name", $"景點名稱 '{attraction.Name}' 已存在，請輸入不同的名稱!");
                    return View(viewModel);
                }
                await _context.Attraction.AddAsync(attraction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
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

        [HttpGet]
        public async Task<IActionResult> editAttraction(Guid attractionID)
        {
            var attraction = await _context.Attraction.FindAsync(attractionID);
            return View(attraction);
        }

        [HttpPost]
        public async Task<IActionResult> editAttraction(Attraction view_attraction)
        {
            // 檢查是否輸入資料
            if (!ModelState.IsValid)
            {
                return View(view_attraction);
            }

            // 檢查是否有重複的景點名稱，除了當前的景點名稱
            if (_context.Attraction.Any(a => a.Name == view_attraction.Name && a.Id != view_attraction.Id))
            {
                ModelState.AddModelError("Name", "景點名稱已存在，請輸入不同的名稱!");
                return View(view_attraction);
            }
            var attraction = await _context.Attraction.FindAsync(view_attraction.Id);
            if(attraction != null)
            {
                attraction.Name = view_attraction.Name;
                attraction.Description = view_attraction.Description;

                _context.Attraction.Update(attraction);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Admin");

        }
    }
}
