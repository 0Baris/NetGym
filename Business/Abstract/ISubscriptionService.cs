using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ISubscriptionService
    {
        IDataResult<List<Subscription>> GetAll();
        IDataResult<Subscription> GetById(int subscriptionId);
        IResult Add(Subscription subscription);
        IResult Update(Subscription subscription);
        IResult Delete(int subscriptionId);
        IDataResult<List<SubscriptionDetailDto>> GetAllByDetails();
        IDataResult<List<SubscriptionDetailDto>> GetDetailsById(int subscriptionId);
    }
}