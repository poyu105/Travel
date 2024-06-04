using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reservations = _context.Reservation
                                        .Include(r => r.Journey)
                                        .Include(r => r.Journey.Attractions)
                                        .Include(r => r.User)
                                        .Where(r => r.UserId == userId)
                                        .ToList();

            var reservationViewModels = reservations.Select(r => new ReservationViewModel
            {
                Journey = r.Journey,
                Attraction = r.Journey.Attractions.ToList(),
                User = r.User,
                Reservations = new List<Reservation> { r },
                People = (int)r.people,
                Remark = r.remark
            }).ToList();

            return View(reservationViewModels);
        }

        [HttpGet]
        public IActionResult Reservation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addReservation(ReservationViewModel view_reservation, int _people, string _remark)
        {
            if (view_reservation.Journey != null)
            {
                var reservation = new Reservation
                {
                    JourneyId = view_reservation.Journey.id,
                    UserId = view_reservation.User.Id,
                    people = _people,
                    remark = _remark,
                    status = 1
                };

                await _context.Reservation.AddAsync(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Reservation");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
