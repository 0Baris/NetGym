using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DealerMemberValidator : AbstractValidator<DealerMember>
    {

        public DealerMemberValidator()
        {
            RuleFor(dm => dm.DealerId)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(dm => dm.MemberId)
                .GreaterThan(0)
                .NotEmpty();
        }
        
    }
}