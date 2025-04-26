using System;
using Core.Constants.Messages;
using Business.Enums;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.FirstName).NotEmpty();
            RuleFor(u=>u.LastName).NotEmpty();
            RuleFor(u=>u.PasswordHash).NotEmpty();
            
            // Email ve Telefon Numarası validasyonu için regex yapısı
            RuleFor(u => u.Email)
                .NotEmpty()
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\+?[1-9]\d{1,14}$");
            
            RuleFor(u => u.CreatedAt)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(u => u.IsActive)
                .Must(status => status == (byte)Status.Active || status == (byte)Status.Inactive)
                .WithMessage(TurkishMessages.InvalidStatus);

            
            
        }
    }
}