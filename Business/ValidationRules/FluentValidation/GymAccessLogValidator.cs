using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class GymAccessLogValidator : AbstractValidator<GymAccessLog>
    {
        public GymAccessLogValidator()
        {
            RuleFor(g => g.MemberId)
                .NotEmpty()
                .GreaterThan(0);
            
            RuleFor(g => g.AccessType)
                .NotEmpty()
                .IsInEnum();
            
            RuleFor(g => g.TrainerId).GreaterThan(0);
            RuleFor(g => g.DealerId).GreaterThan(0);

            RuleFor(g => g.DurationMinutes)
                .NotEmpty();

        }
    }
}