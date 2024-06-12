using System;
using System.Collections.Generic;

namespace HotelListingAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
        public DateTime DateRegistered { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
