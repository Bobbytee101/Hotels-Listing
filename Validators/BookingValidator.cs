using FluentValidation;
using HotelListingAPI.Models;

namespace HotelListingAPI.Validators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(b => b.HotelId).NotEmpty().WithMessage("Hotel ID is required.");
            RuleFor(b => b.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(b => b.CheckInDate).NotEmpty().WithMessage("Check-in date is required.");
            RuleFor(b => b.CheckOutDate).NotEmpty().WithMessage("Check-out date is required.");
            RuleFor(b => b.NumberOfGuests).GreaterThan(0).WithMessage("Number of guests must be greater than zero.");
        }
    }
}
