using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(r => r.RoleName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(r => r.Description)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200);

        }
    }
}