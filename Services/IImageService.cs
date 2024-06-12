using HotelListingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListingAPI.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetImagesAsync();
        Task<Image> GetImageByIdAsync(int id);
        Task<Image> CreateImageAsync(Image image);
        Task<Image> UpdateImageAsync(int id, Image image);
        Task<bool> DeleteImageAsync(int id);
    }
}
