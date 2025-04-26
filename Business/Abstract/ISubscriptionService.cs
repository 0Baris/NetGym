using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ISubscriptionService
    {
        IDataResult<List<SubscriptionDetailDto>> GetAll();
        IDataResult<SubscriptionDetailDto> GetById(int subscriptionId);
        IResult Add(SubscriptionDetailDto subscription);
        IResult Update(SubscriptionDetailDto subscription);
        IResult Delete(int subscriptionId);
        IDataResult<List<SubscriptionDetailDto>> GetAllByDetails();
        IDataResult<List<SubscriptionDetailDto>> GetAllByDetailsById(int subscriptionId);
        IDataResult<List<SubscriptionDetailDto>> GetSubscriptionDetails();
        IDataResult<List<SubscriptionDetailDto>> GetSubscriptionDetailsById(int subscriptionId);
        
    }
}