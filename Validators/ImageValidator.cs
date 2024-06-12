using FluentValidation;
using HotelListingAPI.Models;

namespace HotelListingAPI.Validators
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(i => i.HotelId).NotEmpty().WithMessage("Hotel ID is required.");
            RuleFor(i => i.Url).NotEmpty().WithMessage("URL is required.");
            //RuleFor(i => i.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
