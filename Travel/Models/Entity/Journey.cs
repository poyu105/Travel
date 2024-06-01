namespace Travel.Models.Entity
{
    public class Journey
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string? place { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
