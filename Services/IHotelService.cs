using System.Collections.Generic;
using System.Threading.Tasks;
using HotelListingAPI.Models;

namespace HotelListingAPI.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> AddHotelAsync(Hotel hotel);
        Task<Hotel> UpdateHotelAsync(Hotel hotel);
        Task<bool> DeleteHotelAsync(int id);
    }
}
