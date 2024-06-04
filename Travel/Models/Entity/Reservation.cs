using System.ComponentModel.DataAnnotations.Schema;
using Travel.Areas.Identity.Data;

namespace Travel.Models.Entity
{
    public class Reservation
    {
        public int? id { get; set; }
        public int? people { get; set; }
        public int? status { get; set; }
        public string? UserId { get; set; }
        public int? JourneyId { get; set; }
        public string? remark { get; set; }

        public Journey Journey { get; set; }
        public TravelUser User { get; set; }

    }
}
