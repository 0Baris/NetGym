using System;
using Business.Enums;
using Core.Constants.Messages;
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
                .Must(IsValidIdentityNumber).WithMessage(TurkishMessages.InvalidIdentityNumber);
            
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
        
        public bool IsValidIdentityNumber(string identityNumber)
        {
            if (identityNumber.Length != 11)
                return false;

            if (!long.TryParse(identityNumber, out long idNumber))
                return false;

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += (int)(idNumber % 10);
                idNumber /= 10;
            }

            return sum % 10 == (idNumber % 10);
        }

    }
}