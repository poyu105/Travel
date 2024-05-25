namespace Travel.Models.Entity
{
    public class Attraction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Place {  get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public byte[]? Picture { get; set; }
        public string? Create_at { get; set; }
        public string? Update_at { get; set;}
    }
}
