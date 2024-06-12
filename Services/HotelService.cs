using System.Collections.Generic;
using System.Threading.Tasks;
using HotelListingAPI.Data;
using HotelListingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _context;

        public HotelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Hotels.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Hotel> AddHotelAsync(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> UpdateHotelAsync(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<bool> DeleteHotelAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return false;
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
