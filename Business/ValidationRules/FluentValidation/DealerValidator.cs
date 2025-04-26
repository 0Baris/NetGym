using Core.Constants.Messages;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DealerValidator : AbstractValidator<Dealer>
    {
        public DealerValidator()
        {
            // Dealer kısmını with message ile yaptım diğer yerlerde böyle değil
            RuleFor(d => d.CompanyName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage(TurkishMessages.CompanyNameLength);
                
            
            RuleFor(d => d.UserId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(TurkishMessages.UserIdInvalid);
                
            
            RuleFor(d => d.DealerId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(TurkishMessages.DealerIdInvalid);
                
            
            RuleFor(d => d.Region)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage(TurkishMessages.RegionLength);
                
            
            RuleFor(d => d.TaxNumber)
                .NotEmpty()
                .Length(10,11)
                .WithMessage(TurkishMessages.TaxNumberLength);
            
        }
    }
}