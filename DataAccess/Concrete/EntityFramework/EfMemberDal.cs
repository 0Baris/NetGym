using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMemberDal : EfEntityRepositoryBase<Member, NetGymContext>, IMemberDal
    {
        public List<MemberDetailDto> GetMemberDetails()
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from m in context.Members
                    join u in context.Users on m.UserId equals u.UserId
                    select new MemberDetailDto
                    {
                        MemberId = m.MemberId,
                        IdentityNumber = m.IdentityNumber,
                        Notes = m.Notes,
                        Gender = m.Gender,
                        BirthDate = m.BirthDate,
                        RegistrationDate = m.RegistrationDate,
                        Email = u.Email,
                        MemberName = $"{u.FirstName} {u.LastName}",
                        PhoneNumber = u.PhoneNumber
                    };
                return result.ToList();
            }
        }

        public List<MemberDetailDto> GetMemberDetailById(int memberId)
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from m in context.Members
                    join u in context.Users on m.UserId equals u.UserId where m.MemberId == memberId
                    select new MemberDetailDto
                    {
                        MemberId = m.MemberId,
                        IdentityNumber = m.IdentityNumber,
                        Notes = m.Notes,
                        Gender = m.Gender,
                        BirthDate = m.BirthDate,
                        RegistrationDate = m.RegistrationDate,
                        Email = u.Email,
                        MemberName = $"{u.FirstName} {u.LastName}",
                        PhoneNumber = u.PhoneNumber
                    };
                return result.ToList();
            }
        }

        public List<MemberCampaignDetailDto> GetMemberCampaignDetails()
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from m in context.Members 
                    join u in context.Users on m.UserId equals u.UserId
                    join mc in context.MemberCampaigns on m.MemberId equals mc.MemberId
                    join c in context.Campaigns on m.MemberId equals c.CampaignId where c.CampaignId == mc.CampaignId
                    select new MemberCampaignDetailDto
                    {
                        MemberCampaignId = mc.Id,
                        MemberName = $"{u.FirstName} {u.LastName}",
                        CampaignName = c.Name,
                        RedeemedDate = mc.RedeemedDate,
                        DiscountApplied = mc.DiscountApplied
                    };
                return result.ToList();
            }
        }
        
        public List<MemberCampaignDetailDto> GetMemberCampaignDetailByUserId(int memberId)
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from m in context.Members where m.MemberId == memberId
                    join u in context.Users on m.UserId equals u.UserId
                    join mc in context.MemberCampaigns on m.MemberId equals mc.MemberId
                    join c in context.Campaigns on m.MemberId equals c.CampaignId where c.CampaignId == mc.CampaignId
                    select new MemberCampaignDetailDto
                    {
                        MemberCampaignId = mc.Id,
                        MemberName = $"{u.FirstName} {u.LastName}",
                        CampaignName = c.Name,
                        RedeemedDate = mc.RedeemedDate,
                        DiscountApplied = mc.DiscountApplied
                    };
                return result.ToList();
            }
        }
        
    }
}