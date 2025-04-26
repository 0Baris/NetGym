using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IMemberDal : IEntityRepository<Member>
    {
        List<MemberDetailDto> GetMemberDetails();
        List<MemberDetailDto> GetMemberDetailById(int memberId);
        List<MemberCampaignDetailDto> GetMemberCampaignDetails();
        List<MemberCampaignDetailDto> GetMemberCampaignDetailByUserId(int userId);

    }
}