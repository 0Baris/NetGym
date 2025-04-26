using System.Collections.Generic;
using Business.Abstract;
using Core.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DealerMemberManager : IDealerMemberService
    {
        private readonly IDealerMemberDal _dealerMemberDal;
        private readonly IMemberDal _memberDal;

        public DealerMemberManager(IDealerMemberDal dealerMemberDal, IMemberDal memberDal)
        {
            _dealerMemberDal = dealerMemberDal;
            _memberDal = memberDal;
        }

        
        public IDataResult<List<DealerMember>> GetAll(int dealerId)
        {
            return new SuccessDataResult<List<DealerMember>>(_dealerMemberDal.GetAll());
        }

        public IDataResult<DealerMember> GetById(int dealerMemberId)
        {
            return new SuccessDataResult<DealerMember>(_dealerMemberDal.Get(dm => dm.Id == dealerMemberId));
        }

        [ValidationAspect(typeof(DealerMemberValidator))]
        public IResult Add(DealerMember dealerMember)
        {
            IResult result = BusinessRules.Run(
                CheckIfDealerMemberIdentityExists(dealerMember.MemberId));
            
            if (result != null)
            {
                return result;
            }
            _dealerMemberDal.Add(dealerMember);
            
            return new SuccessResult(TurkishMessages.DealerMemberAdded);
        }
        
        [ValidationAspect(typeof(DealerMemberValidator))]
        public IResult Update(DealerMember dealerMember)
        {
            IResult result = BusinessRules.Run(
                CheckIfDealerMemberIdentityExists(dealerMember.MemberId));
            
            if (result != null)
            {
                return result;
            }
            
            _dealerMemberDal.Update(dealerMember);
            
            return new SuccessResult(TurkishMessages.DealerMemberUpdated);
        }

        public IResult Delete(int dealerMemberId)
        {
            var result = BusinessRules.ValidateEntityExistence(
                _dealerMemberDal, dealerMemberId
                , dm => dm.DealerId == dealerMemberId);
            
            if (result != null)
            {
                return result;
            }
            
            var dealerMember = _dealerMemberDal.Get(dm => dm.Id == dealerMemberId);
            _dealerMemberDal.Delete(dealerMember);
            
            return new SuccessResult(TurkishMessages.DealerMemberDeleted);
        }
        
        private IResult CheckIfDealerMemberIdentityExists(int memberId)
        {
            var member = _memberDal.Get(m => m.MemberId == memberId);

            if (member != null)
            {
                var dealerMember = _dealerMemberDal.Get(dm => dm.MemberId == member.MemberId);

                if (dealerMember != null && !string.IsNullOrEmpty(member.IdentityNumber))
                {
                    return new ErrorResult(TurkishMessages.IdentityNumberAlreadyExists);
                }
            }

            return new SuccessResult();
        }
    }
}