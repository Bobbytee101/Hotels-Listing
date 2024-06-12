using System.Collections.Generic;
using System.Threading.Tasks;
using HotelListingAPI.Models;

namespace HotelListingAPI.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> AddBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(int id);
    }
}
