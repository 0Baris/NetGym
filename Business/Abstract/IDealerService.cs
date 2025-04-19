using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IDealerService
    {
        IDataResult<List<Dealer>> GetAll();
        Dealer GetById(int dealerId);
        IResult Add(Dealer dealer);
        IResult Update(Dealer dealer);
        IResult Delete(int dealerId);
        IDataResult<List<DealerDetailsDto>> GetDealerDetails();
        IDataResult<List<Dealer>> GetByCampaignId(int campaignId);
        IDataResult<List<Dealer>> GetByCampaignIdAndIsActive(int campaignId, byte isActive);
        
        
    }
}