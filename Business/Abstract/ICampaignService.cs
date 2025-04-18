using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        List<Campaign> GetAll();
        Campaign GetById(int campaignId);
        void Add(Campaign campaign);
        void Update(Campaign campaign);
        void Delete(Campaign campaign);
    }
}