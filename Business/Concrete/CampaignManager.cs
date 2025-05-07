using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private ICampaignDal _campaignDal;
        
        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
        }
        
        public IDataResult<List<Campaign>> GetAll()
        {
            return new SuccessDataResult<List<Campaign>>(_campaignDal.GetAll());
        }

        public IDataResult<Campaign> GetById(int campaignId)
        {
            return new SuccessDataResult<Campaign>(_campaignDal.Get(c=> c.CampaignId == campaignId), TurkishMessages.Success);
        }

        [SecuredOperation("admin,dealer.admin")]
        [ValidationAspect(typeof(CampaignValidator))]
        public IResult Add(Campaign campaign)
        {
            IResult result = BusinessRules.Run(
                CheckIfCampaignExists(campaign.Name),
                            CheckIfCampaignLimitExceeded());
            
            if (result != null)
            {
                return result;
            }
            
            _campaignDal.Add(campaign);
            
            return new SuccessResult(TurkishMessages.CampaignAdded);
        }

        [SecuredOperation("admin,dealer.admin")]
        [ValidationAspect(typeof(CampaignValidator))]
        public IResult Update(Campaign campaign)
        {
            var result = BusinessRules.Run(
                BusinessRules.ValidateEntityExistence(
                _campaignDal,
                campaign.CampaignId,
                c => c.CampaignId == campaign.CampaignId), 
                CheckIfCampaignExists(campaign.Name));

            if (result != null)
            {
                return result;
            }

            _campaignDal.Update(campaign);
            return new SuccessResult(TurkishMessages.CampaignUpdated);
        }

        [SecuredOperation("admin,dealer.admin")]
        public IResult Delete(int campaignId)
        {
            var result = BusinessRules.ValidateEntityExistence(
                _campaignDal,
                campaignId, 
                c => c.CampaignId == campaignId)
                ;

            if (result != null)
            {
                return result;
            }
            
            var campaign = _campaignDal.Get(c => c.CampaignId == campaignId);
            _campaignDal.Delete(campaign);
            
            return new SuccessResult(TurkishMessages.CampaignDeleted);
        }

        private IResult CheckIfCampaignExists(string campaignName)
        {
            var result = _campaignDal.GetAll(c => c.Name == campaignName).Any();
            if (result)
            {
                return new ErrorResult(TurkishMessages.NameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCampaignLimitExceeded()
        {
            var result = _campaignDal.GetAll().Count;
            if (result >= 7)
            {
                return new ErrorResult(TurkishMessages.CampaignLimitExceeded);
            }

            return new SuccessResult();
        }
    }
}