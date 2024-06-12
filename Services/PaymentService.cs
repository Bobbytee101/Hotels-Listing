using System.Collections.Generic;
using System.Threading.Tasks;
using HotelListingAPI.Data;
using HotelListingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _context.Payments.Include(p => p.Booking).ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Payments.Include(p => p.Booking).FirstOrDefaultAsync(p => p.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Payment> AddPaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdatePaymentAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return false;
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
