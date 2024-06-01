using Essentials;
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

        [HttpGet]
        public IActionResult addAttraction(int journeyId)
        {
            var viewModel = new AttractionListViewModel
            {
                JourneyId = journeyId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> addAttraction(AttractionListViewModel viewModel)
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

                // Set the JourneyId for each attraction
                attraction.Journey_id = viewModel.JourneyId;
                await _context.Attraction.AddAsync(attraction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }


        [HttpPost]
        public async Task<IActionResult> delAttraction(int journey_id)
        {
            // 找到与给定 journey_id 相关的所有 Attraction
            var attractions = _context.Attraction.Where(a => a.Journey_id == journey_id);

            // 循环删除每个匹配的 Attraction
            foreach (var attraction in attractions)
            {
                _context.Attraction.Remove(attraction);
            }

            // 保存更改
            await _context.SaveChangesAsync();

            return RedirectToAction("delJourney", "Journey", new {id = journey_id});
        }


        [HttpGet]
        public async Task<IActionResult> editAttraction(int journeyId)
        {
            // 從資料庫獲取具有相同 JourneyId 的景點
            var attractions = await _context.Attraction
                .Where(a => a.Journey_id == journeyId)
                .Take(5)
                .ToListAsync();

            // 填充 ViewModel，確保總是有五個 Attraction 物件
            var viewModel = new AttractionListViewModel
            {
                JourneyId = journeyId
            };

            // 將已存在的資料填充到 ViewModel 中
            for (int i = 0; i < attractions.Count; i++)
            {
                viewModel.Attractions[i] = attractions[i];
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAttraction(AttractionListViewModel view_attractionList)
        {
            // 檢查是否輸入資料
            if (!ModelState.IsValid)
            {
                return View(view_attractionList);
            }

            // 獲取所有的 Attraction
            foreach (var view_attraction in view_attractionList.Attractions)
            {
                // 找到對應的 Attraction
                var attraction = await _context.Attraction.FindAsync(view_attraction.Id);
                if (attraction != null)
                {
                    // 更新資料
                    attraction.Name = view_attraction.Name;
                    attraction.Description = view_attraction.Description;

                    // 標記為已修改
                    _context.Attraction.Update(attraction);
                }
            }

            // 保存更改
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Admin");
        }
    }
}
