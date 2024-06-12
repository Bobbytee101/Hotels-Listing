using System.Collections.Generic;
using System.Threading.Tasks;
using HotelListingAPI.Models;

namespace HotelListingAPI.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<Payment> AddPaymentAsync(Payment payment);
        Task<Payment> UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(int id);
    }
}
