using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        IDataResult<List<Campaign>> GetAll();
        IDataResult<Campaign> GetById(int campaignId);
        IResult Add(Campaign campaign);
        IResult Update(Campaign campaign);
        IResult Delete(int campaignId);
    }
}