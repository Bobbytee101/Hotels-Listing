using FluentValidation;
using HotelListingAPI.Models;

namespace HotelListingAPI.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.BookingId).NotEmpty().WithMessage("Booking ID is required.");
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0.");
            RuleFor(p => p.PaymentMethod).NotEmpty().WithMessage("Payment method is required.");
        }
    }
}
