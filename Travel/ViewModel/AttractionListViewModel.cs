using System.Collections.Generic;
using Travel.Models.Entity;

namespace Travel.ViewModels
{
    public class AttractionListViewModel
    {
        public int JourneyId { get; set; }

        public List<Attraction> Attractions { get; set; } = new List<Attraction>
        {
            new Attraction(),
            new Attraction(),
            new Attraction(),
            new Attraction(),
            new Attraction()
        };
    }
}
