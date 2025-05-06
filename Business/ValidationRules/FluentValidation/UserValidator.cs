using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(u => u.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(u => u.Email)
                .NotEmpty()
                .MaximumLength(100)
                .EmailAddress();

            RuleFor(u => u.PhoneNumber)
                .MaximumLength(20);

            RuleFor(u => u.PasswordHash)
                .NotNull();

            RuleFor(u => u.PasswordSalt)
                .NotNull();
        }
    }
}