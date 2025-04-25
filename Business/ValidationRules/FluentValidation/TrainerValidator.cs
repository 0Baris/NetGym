using Business.Constants.Messages;
using Business.Enums;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TrainerValidator : AbstractValidator<Trainer>
    {
        public TrainerValidator()
        {
            RuleFor(t => t.DealerId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(t=>t.UserId)
                .NotEmpty()
                .GreaterThan(0);
            
            RuleFor(t=>t.Bio)
                .NotEmpty()
                .MinimumLength(20)
                .MaximumLength(150);
            
            RuleFor(t => t.Specialization)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);
            
            RuleFor(t => t.IsActive)
                .Must(status => status == (byte)Status.Active || status == (byte)Status.Inactive)
                .WithMessage(TurkishMessages.InvalidStatus);
        }
    }
}