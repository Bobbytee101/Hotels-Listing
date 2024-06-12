using HotelListingAPI.Data;
using HotelListingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListingAPI.Services
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;

        public ImageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetImageByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Images.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Image> CreateImageAsync(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> UpdateImageAsync(int id, Image image)
        {
            var existingImage = await _context.Images.FindAsync(id);
            if (existingImage == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            existingImage.Url = image.Url;
            existingImage.HotelId = image.HotelId;

            _context.Images.Update(existingImage);
            await _context.SaveChangesAsync();

            return existingImage;
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return false;
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
