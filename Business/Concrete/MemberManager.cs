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
    public class MemberManager : IMemberService
    {
        
        private readonly IMemberDal _memberDal;
        
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }
        
        public IDataResult<List<Member>> GetAll()
        {
            return new SuccessDataResult<List<Member>>(_memberDal.GetAll());
        }

        public IDataResult<List<MemberDetailDto>> GetMemberDetails()
        {
            return new SuccessDataResult<List<MemberDetailDto>>(_memberDal.GetMemberDetails());
        }

        public IDataResult<List<MemberDetailDto>> GetMemberDetailsById(int memberId)
        {
            return new SuccessDataResult<List<MemberDetailDto>>(_memberDal.GetMemberDetailById(memberId), TurkishMessages.Success);
        }

        public IDataResult<List<MemberCampaignDetailDto>> GetMemberCampaignDetails()
        {
            return new SuccessDataResult<List<MemberCampaignDetailDto>>(_memberDal.GetMemberCampaignDetails(), TurkishMessages.Success);
        }

        public IDataResult<List<MemberCampaignDetailDto>> GetMemberCampaignDetailByUserId(int memberId)
        {
            return new SuccessDataResult<List<MemberCampaignDetailDto>>(_memberDal.GetMemberCampaignDetailByUserId(memberId) , TurkishMessages.Success);
        }

        public IDataResult<Member> GetById(int memberId)
        {
            return new SuccessDataResult<Member>(_memberDal.Get(u => u.MemberId == memberId), TurkishMessages.Success);
        }

        [ValidationAspect(typeof(MemberValidator))]
        public IResult Add(Member member)
        {
            
            IResult result = BusinessRules.Run(
                CheckIfMemberIdentityExists(member.IdentityNumber));
            
            if (result != null)
            {
                return result;
            }
            
            _memberDal.Add(member);
            
            return new SuccessResult("Member added successfully.");
            
        }
        
        [ValidationAspect(typeof(MemberValidator))]
        public IResult Update(Member member)
        {
            IResult result = BusinessRules.Run(
                CheckIfMemberIdentityExists(member.IdentityNumber));
            
            if (result != null)
            {
                return result;
            }

            _memberDal.Update(member);
            
            return new SuccessResult(TurkishMessages.MemberUpdated);
        }

        public IResult Delete(int memberId)
        {
            var result = BusinessRules.ValidateEntityExistence(
                _memberDal,
                memberId, 
                m => m.MemberId == memberId);
            
            if (result != null)
            {
                return result;
            }
            
            var member = _memberDal.Get(m => m.MemberId == memberId);
            _memberDal.Delete(member);
            return new SuccessResult(TurkishMessages.MemberDeleted);
            
        }

        private IResult CheckIfMemberIdentityExists(string identityNumber)
        {
            var member = _memberDal.Get(m => m.IdentityNumber == identityNumber);
            if (member != null)
            {
                return new ErrorResult(TurkishMessages.IdentityNumberAlreadyExists);
            }

            return new SuccessResult();
        }
    }
        
}