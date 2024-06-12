using System.Collections.Generic;
using System.Threading.Tasks;
using HotelListingAPI.Data;
using HotelListingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            return await _context.Reviews.Include(r => r.Hotel).Include(r => r.User).ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Reviews.Include(r => r.Hotel).Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> UpdateReviewAsync(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
