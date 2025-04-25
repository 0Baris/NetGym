using System;
using Business.Enums;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MemberValidator : AbstractValidator<Member>
    {
        
        public MemberValidator()
        {
            RuleFor(m => m.UserId)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(m => m.IdentityNumber)
                .NotEmpty()
                .Length(11);
            
            RuleFor(m => m.BirthDate)
                .NotEmpty()
                .LessThan(DateTime.Now.AddYears(-16));

            RuleFor(m => m.RegistrationDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);
            
            RuleFor(m => m.Gender)
                .Must(gender => gender == 'F' || gender == 'M')
                .WithMessage("Cinsiyet geçerli bir değer olmalıdır (F: Kadın, M: Erkek).");
            
        }      

    }
}