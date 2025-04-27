using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ISubscriptionDal : IEntityRepository<Subscription>
    {
        List<SubscriptionDetailDto> GetSubscriptionDetails();
        List<SubscriptionDetailDto> GetSubscriptionDetailById(int subscriptionId);
    }
}