using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constants.Messages;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class SubscriptionManager : ISubscriptionService
    {
        
        private readonly ISubscriptionDal _subscriptionDal;
        private readonly IMemberDal _memberDal;
        private readonly IPackageDal _packageDal;

        public SubscriptionManager(ISubscriptionDal subscriptionDal, IMemberDal memberDal, IPackageDal packageDal)
        {
            _subscriptionDal = subscriptionDal;
            _memberDal = memberDal;
            _packageDal = packageDal;
        }

        public IDataResult<List<Subscription>> GetAll()
        {
            return new SuccessDataResult<List<Subscription>>(_subscriptionDal.GetAll(), TurkishMessages.Success);
        }

        public IDataResult<Subscription> GetById(int subscriptionId)
        {
            return new SuccessDataResult<Subscription>(_subscriptionDal.Get(c => c.SubscriptionId == subscriptionId));
        }

        [ValidationAspect(typeof(SubscriptionValidator))]
        public IResult Add(Subscription subscription)
        {
            var result = BusinessRules.Run(CheckIfMemberExists(subscription.MemberId), CheckIfPackageExists(subscription.PackageId));
        
            if (result != null)
            {
                return result;
            }
            
            _subscriptionDal.Add(subscription);
            return new SuccessResult(TurkishMessages.SubscriptionAdded);
        }
        
        [ValidationAspect(typeof(SubscriptionValidator))]
        public IResult Update(Subscription subscription)
        {
            var result = BusinessRules.Run(CheckIfMemberExists(subscription.MemberId), CheckIfPackageExists(subscription.PackageId));
        
            if (result != null)
            {
                return result;
            }
            
            _subscriptionDal.Update(subscription);
            return new SuccessResult(TurkishMessages.SubscriptionUpdated);
        }

        public IResult Delete(int subscriptionId)
        {
            BusinessRules.ValidateEntityExistence(
                _subscriptionDal, subscriptionId, s => s.SubscriptionId == subscriptionId);
            
            var subscriptionToDelete = _subscriptionDal.Get(s => s.SubscriptionId == subscriptionId);
            _subscriptionDal.Delete(subscriptionToDelete);
            return new SuccessResult(TurkishMessages.SubscriptionDeleted);
        }

        public IDataResult<List<SubscriptionDetailDto>> GetAllByDetails()
        {
            return new SuccessDataResult<List<SubscriptionDetailDto>>(_subscriptionDal.GetSubscriptionDetails(), TurkishMessages.Success);
        }

        public IDataResult<List<SubscriptionDetailDto>> GetDetailsById(int subscriptionId)
        {
            return new SuccessDataResult<List<SubscriptionDetailDto>>(_subscriptionDal.GetSubscriptionDetailById(subscriptionId), TurkishMessages.Success);
        }
        
        private IResult CheckIfMemberExists(int memberId)
        {
            var result = _memberDal.Get(m => m.MemberId == memberId);
            if (result == null)
            {
                return new ErrorResult(TurkishMessages.ErrorOccurred);
            }
            return new SuccessResult();
        }

        private IResult CheckIfPackageExists(int packageId)
        {
            var result = _packageDal.Get(p => p.PackageId == packageId);
            if (result == null)
            {
                return new ErrorResult(TurkishMessages.ErrorOccurred);
            }
            return new SuccessResult();
        }
        
    }
}