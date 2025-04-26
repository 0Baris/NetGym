using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class SubscriptionManager : ISubscriptionService
    {
        public IDataResult<List<SubscriptionDetailDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<SubscriptionDetailDto> GetById(int subscriptionId)
        {
            throw new System.NotImplementedException();
        }


        public IResult Add(SubscriptionDetailDto subscription)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(SubscriptionDetailDto subscription)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(int subscriptionId)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<SubscriptionDetailDto>> GetAllByDetails()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<SubscriptionDetailDto>> GetAllByDetailsById(int subscriptionId)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<SubscriptionDetailDto>> GetSubscriptionDetails()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<SubscriptionDetailDto>> GetSubscriptionDetailsById(int subscriptionId)
        {
            throw new System.NotImplementedException();
        }
    }
}