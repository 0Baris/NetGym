using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IMemberService
    {
        IDataResult<List<Member>> GetAll();
        IDataResult<List<MemberDetailDto>> GetMemberDetails();
        IDataResult<List<MemberDetailDto>> GetMemberDetailsById(int memberId);
        IDataResult<List<MemberCampaignDetailDto>> GetMemberCampaignDetails();
        IDataResult<List<MemberCampaignDetailDto>> GetMemberCampaignDetailByUserId(int userId);
        IDataResult<Member> GetById(int memberId);
        IResult Add(Member member);
        IResult Update(Member member);
        IResult Delete(int memberId);
    }
}