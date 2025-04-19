using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMemberCampaignDal : EfEntityRepositoryBase<MemberCampaign, NetGymContext>, IMemberCampaignDal
    {

        public List<MemberCampaignDetailDto> GetMemberCampaignDetails()
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from mc in context.MemberCampaigns
                    join m in context.Members on mc.MemberId equals m.MemberId
                    join c in context.Campaigns on mc.CampaignId equals c.CampaignId
                    join u in context.Users on m.UserId equals u.UserId
                    select new MemberCampaignDetailDto
                    {
                        // veritabanı kısmında hata yapmışım olması gereken değer MemberCampaignId
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