using System.Collections.Generic;
using System.Linq;
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
    public class DealerManager : IDealerService
    {
        
        private readonly IDealerDal _dealerDal;
        
        public DealerManager(IDealerDal dealerDal)
        {
            _dealerDal = dealerDal;
        }
        
        public IDataResult<List<Dealer>> GetAll()
        {
            return new SuccessDataResult<List<Dealer>>(_dealerDal.GetAll());
        }

        public IDataResult<Dealer> GetById(int dealerId)
        {
            return new SuccessDataResult<Dealer>(_dealerDal.Get(d => d.DealerId == dealerId));
        }

        [ValidationAspect(typeof(DealerValidator))]
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
        
        [ValidationAspect(typeof(DealerValidator))]
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
        
        private IResult CheckIfDealerExists(string dealerName)
        {
            var result = _dealerDal.GetAll(d => d.CompanyName == dealerName).Any();
            if (result)
            {
                return new ErrorResult(TurkishMessages.NameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}