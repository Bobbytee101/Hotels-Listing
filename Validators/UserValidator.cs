using FluentValidation;
using HotelListingAPI.Models;

namespace HotelListingAPI.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username).NotEmpty().WithMessage("Username is required.");
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
            RuleFor(u => u.PasswordHash).NotEmpty().WithMessage("Password is required.");
        }
    }
}
