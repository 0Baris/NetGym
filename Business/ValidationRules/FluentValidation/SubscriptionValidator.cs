using Business.Enums;
using Core.Constants.Messages;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SubscriptionValidator : AbstractValidator<Subscription>
    {

        public SubscriptionValidator()
        {
            RuleFor(x => x.PackageId).NotEmpty();
            RuleFor(x => x.MemberId).NotEmpty();
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .LessThanOrEqualTo(x => x.EndDate);
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => x.StartDate);
            RuleFor(x => x.AutoRenew)
                .NotEmpty()
                .Must(status => status == (byte)Status.Active || status == (byte)Status.Inactive)
                .WithMessage(TurkishMessages.InvalidStatus);
            
            RuleFor(x => x.Status)
                .NotEmpty()
                .Must(status => byte.TryParse(status, out var parsedStatus) && 
                                (parsedStatus == (byte)Status.Active || parsedStatus == (byte)Status.Inactive))
                .WithMessage(TurkishMessages.InvalidStatus);
        }
        
    }
}