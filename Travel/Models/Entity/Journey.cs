namespace Travel.Models.Entity
{
    public class Journey
    {
        public int id { get; set; }
        public string? place { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
    }
}
