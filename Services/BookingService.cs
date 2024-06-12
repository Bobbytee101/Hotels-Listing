using System.Collections.Generic;
using System.Threading.Tasks;
using HotelListingAPI.Data;
using HotelListingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings.Include(b => b.Hotel).Include(b => b.User).ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Bookings.Include(b => b.Hotel).Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return false;
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
