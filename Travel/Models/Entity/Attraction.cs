using System.ComponentModel.DataAnnotations;

namespace Travel.Models.Entity
{
    public class Attraction
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="景點名稱是必須的!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "描述是必須的!")]
        public string Description { get; set; }
    }
}
