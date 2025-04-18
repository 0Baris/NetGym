using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDealerService
    {
        List<Dealer> GetAll();
        Dealer GetById(int dealerId);
        void Add(Dealer dealer);
        void Update(Dealer dealer);
        void Delete(Dealer dealer);
        List<Dealer> GetByCampaignId(int campaignId);
        List<Dealer> GetByCampaignIdAndIsActive(int campaignId, byte isActive);
        
        
    }
}