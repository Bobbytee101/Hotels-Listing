using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HotelListingAPI.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
        public decimal PricePerNight { get; set; }

        [JsonIgnore]
        public virtual ICollection<Review>? Reviews { get; set; }
        [JsonIgnore]
        public virtual ICollection<Booking>? Bookings { get; set; }
        [JsonIgnore]
        public virtual ICollection<Image>? Images { get; set; }
    }
}
