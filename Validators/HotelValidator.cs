using FluentValidation;
using HotelListingAPI.Models;

namespace HotelListingAPI.Validators
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(h => h.Name).NotEmpty().WithMessage("Hotel name is required.");
            RuleFor(h => h.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(h => h.Rating).InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
        }
    }
}
