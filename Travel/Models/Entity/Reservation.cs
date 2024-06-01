namespace Travel.Models.Entity
{
    public class Reservation
    {
        public int? id { get; set; }
        public int? people { get; set; }
        public int? status { get; set; }
        public int? user_id { get; set; }
        public int? Journey_id { get; set; }
        public string? remark { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
