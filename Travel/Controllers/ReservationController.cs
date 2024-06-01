using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Travel.Areas.Identity.Data;
using Travel.Models;
using Travel.Models.Entity;

namespace Travel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly TravelContext _context;

        public ReservationController(TravelContext mvcDBContext)
        {
            _context = mvcDBContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var reservation = _context.Reservation.ToList();
            return View(reservation);
        }
        [HttpGet]
        public IActionResult Reservation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addReservation(Reservation view_reservation)
        {
            var reservation = new Reservation
            {
                people = view_reservation.people,
                status = view_reservation.status,
                remark = view_reservation.remark,
            };

            await _context.Reservation.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction("addReservation", "Admin");
        }
        [HttpPatch]
        public async Task<IActionResult> editReservation(Reservation view_reservation)
        {
            // 檢查是否輸入資料
            if (!ModelState.IsValid)
            {
                return View(view_reservation);
            }

            var reservation = await _context.Reservation.FindAsync(view_reservation.id);
            if (reservation != null)
            {
                reservation.people = view_reservation.people;
                reservation.status = view_reservation.status;
                reservation.remark = view_reservation.remark;

                _context.Reservation.Update(reservation);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("showReservation", "Admin");
        }
        [HttpPost]
        public async Task<IActionResult> deleteReservation(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("showReservation", "Admin");
        }
    }
}
