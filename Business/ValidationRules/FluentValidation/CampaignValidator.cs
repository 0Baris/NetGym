using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using Business.Enums;

namespace Business.ValidationRules.FluentValidation
{
    public class CampaignValidator : AbstractValidator<Campaign>
    {

        public CampaignValidator()
        {
            // kampanya adı boş olamaz ve en az 2 karakter olmalı
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            
            // başlangıç ve bitiş tarihleri boş olamaz
            RuleFor(c => c.StartDate).NotEmpty();
            RuleFor(c => c.EndDate).NotEmpty();
            // başlangıç tarihi bitiş tarihinden küçük olmalı
            RuleFor(c => c.EndDate).GreaterThan(c => c.StartDate);
            
            RuleFor(c => c.Description).NotEmpty();
            // indirim oranı 0,100 arasında olmalı ve boş olamaz
            RuleFor(c => c.DiscountPercentage).NotEmpty();
            RuleFor(c => c.DiscountPercentage).InclusiveBetween(0, 100);
            
            // idler boş olamaz!
            RuleFor(c => c.TargetDealerId).GreaterThan(0);
            RuleFor(c => c.TargetDealerId).NotEmpty();

            
            // kampanya durumu boş olamaz ve enum değerlerinden biri olmalı
            RuleFor(c => c.IsActive)
                .Must(status => status == (byte)Status.Active || status == (byte)Status.Inactive)
                .WithMessage(TurkishMessages.InvalidStatus);
        }
    }
}