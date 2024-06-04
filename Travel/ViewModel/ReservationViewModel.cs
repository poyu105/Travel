using Travel.Areas.Identity.Data;
using Travel.Models.Entity;

public class ReservationViewModel
{
    public Journey Journey { get; set; }
    public List<Attraction> Attraction { get; set; }
    public TravelUser User { get; set; }
    public List<Reservation> Reservations { get; set; }
}
