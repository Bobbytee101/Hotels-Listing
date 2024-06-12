namespace HotelListingAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int UserId { get; set; }
        public string? ReviewText { get; set; }
        public int Rating { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual User? User { get; set; }
    }
}
