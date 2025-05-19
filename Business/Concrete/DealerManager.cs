using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Constants.Messages;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class DealerManager : IDealerService
    {
        
        private IDealerDal _dealerDal;
        
        public DealerManager(IDealerDal dealerDal)
        {
            _dealerDal = dealerDal;
        }
        
        [CacheAspect]
        public IDataResult<List<Dealer>> GetAll()
        {
            return new SuccessDataResult<List<Dealer>>(_dealerDal.GetAll());
        }

        public IDataResult<Dealer> GetById(int dealerId)
        {
            return new SuccessDataResult<Dealer>(_dealerDal.Get(d => d.DealerId == dealerId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public IResult Add(Dealer dealer)
        {
            IResult result = BusinessRules.Run(
                CheckIfDealerExists(dealer.CompanyName));
            
            if (result != null)
            {
                return result;
            }
            _dealerDal.Add(dealer);
            
            return new SuccessResult(TurkishMessages.DealerAdded);
        }
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public IResult Update(Dealer dealer)
        {
            IResult result = BusinessRules.Run(
                CheckIfDealerExists(dealer.CompanyName));
            
            if (result != null)
            {
                return result;
            }
            _dealerDal.Update(dealer);
            
            return new SuccessResult(TurkishMessages.DealerUpdated);
        }
        
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IDealerService.Get")]
        public IResult Delete(int dealerId)
        {
            var result = BusinessRules.ValidateEntityExistence(_dealerDal, dealerId , d => d.DealerId == dealerId);
            
            if (result != null)
            {
                return result;
            }
            var dealer = _dealerDal.Get(d => d.DealerId == dealerId);
            _dealerDal.Delete(dealer);
            return new SuccessResult(TurkishMessages.DealerDeleted);
        }

        public IDataResult<List<DealerDetailsDto>> GetDealerDetails()
        {
            return new SuccessDataResult<List<DealerDetailsDto>>(_dealerDal.GetDealerDetails(), TurkishMessages.Success);
        }

        public IDataResult<List<DealerDetailsDto>> GetDealerDetailsById(int dealerId)
        {
            return new SuccessDataResult<List<DealerDetailsDto>>(_dealerDal.GetDealerDetailsById(dealerId), TurkishMessages.Success);
        }

        private IResult CheckIfDealerExists(string dealerName)
        {
            var result = _dealerDal.GetAll(d => d.CompanyName == dealerName).Any();
            if (result)
            {
                return new ErrorResult(TurkishMessages.NameAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<Dealer> GetByRegion(string region)
        {
            var dealer = _dealerDal.GetAll(d =>
                    d.Region.Replace(" ", "").ToLowerInvariant() == region.Replace(" ", "").ToLowerInvariant())
                .FirstOrDefault();
            if (dealer == null)
            {
                return new ErrorDataResult<Dealer>(TurkishMessages.RegionError);
            }
            return new SuccessDataResult<Dealer>(dealer);
        }
    }
}