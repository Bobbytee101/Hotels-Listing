using FluentValidation;
using HotelListingAPI.Models;

namespace HotelListingAPI.Validators
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(r => r.HotelId).NotEmpty().WithMessage("Hotel ID is required.");
            RuleFor(r => r.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(r => r.ReviewText).NotEmpty().WithMessage("Comment is required.");
            RuleFor(r => r.Rating).InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
        }
    }
}
