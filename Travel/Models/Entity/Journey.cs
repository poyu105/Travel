using System.ComponentModel.DataAnnotations;

namespace Travel.Models.Entity
{
    public class Journey
    {
        public int id { get; set; }
        [Required(ErrorMessage = "行程名稱是必須的!")]
        public string? place { get; set; }
        [Required(ErrorMessage = "開始時間是必須的!")]
        public DateTime? start_date { get; set; }
        [Required(ErrorMessage = "結束時間是必須的!")]
        public DateTime? end_date { get; set; }
        public List<Attraction> Attractions { get; set; }
    }
}
