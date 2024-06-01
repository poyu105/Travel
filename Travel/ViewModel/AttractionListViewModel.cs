using System.Collections.Generic;
using Travel.Models.Entity;

namespace Travel.ViewModels
{
    public class AttractionListViewModel
    {
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
