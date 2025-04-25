using Business.Constants.Messages;
using Business.Enums;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PackageValidator : AbstractValidator<Package>
    {
        public PackageValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            
            RuleFor(p => p.Description)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(p => p.Price) 
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.DurationDays)
                .NotEmpty()
                .GreaterThan(0);
            
            RuleFor(p => p.IsActive)
                .Must(status => status == (byte)Status.Active || status == (byte)Status.Inactive)
                .WithMessage(TurkishMessages.InvalidStatus);
        }
    }
}