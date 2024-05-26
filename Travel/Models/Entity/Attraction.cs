using System.ComponentModel.DataAnnotations;

namespace Travel.Models.Entity
{
    public class Attraction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage ="景點名稱是必須的!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "地點是必須的!")]
        public string Place {  get; set; }
        [Required(ErrorMessage = "描述是必須的!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "類型是必須的!")]
        public string Type { get; set; }
        public byte[]? Picture { get; set; }
        public string? Create_at { get; set; }
        public string? Update_at { get; set;}
    }
}
