using System.Collections.Generic;
using Business.Abstract;
using Business.Constants.Messages;
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

        public IResult Add(Campaign campaign)
        {
            _campaignDal.Add(campaign);
            
            return new SuccessResult(TurkishMessages.CampaignAdded);
        }

        public IResult Update(Campaign campaign)
        {
            _campaignDal.Update(campaign);
            
            return new SuccessResult(TurkishMessages.CampaignUpdated);
        }

        public IResult Delete(int campaignId)
        {
            if (campaignId <= 0)
            {
                return new ErrorResult(TurkishMessages.ErrorOccurred);
            }
            if (_campaignDal.Get(c => c.CampaignId == campaignId) == null)
            {
                return new ErrorResult(TurkishMessages.ErrorOccurred);
            }
            
            var campaign = _campaignDal.Get(c => c.CampaignId == campaignId);
            _campaignDal.Delete(campaign);
            
            return new SuccessResult(TurkishMessages.CampaignDeleted);
        }
    }
}