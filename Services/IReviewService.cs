using System.Collections.Generic;
using System.Threading.Tasks;
using HotelListingAPI.Models;

namespace HotelListingAPI.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review> AddReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(int id);
    }
}
