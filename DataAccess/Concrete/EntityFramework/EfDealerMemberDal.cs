using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDealerMemberDal : EfEntityRepositoryBase<DealerMember, NetGymContext>, IDealerMemberDal
    {
        public List<DealerWithMembersDto> GetDealerWithMembers(int dealerId)
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = 
                    from dm in context.DealerMembers where dm.DealerId == dealerId
                    join d in context.Dealers on dm.DealerId equals d.DealerId
                    join m in context.Members on dm.MemberId equals m.MemberId
                    join u in context.Users on m.UserId equals u.UserId
                    select new DealerWithMembersDto
                    {
                        MemberId = dm.MemberId,
                        DealerId = dm.DealerId,
                        DealerName = d.CompanyName,
                        DealerPhoneNumber = u.PhoneNumber,
                        DealerEmail = u.Email,
                        DealerAddress = d.Region,
                        MemberName = $"{u.FirstName} {u.LastName}",
                        MemberPhoneNumber = u.PhoneNumber,
                        MemberEmail = u.Email,
                        MemberIdentityNumber = m.IdentityNumber,
                        MemberBirthDate = m.BirthDate,
                        MemberRegistrationDate = m.RegistrationDate,
                    };
                return result.ToList();
            }
            
        }
    }
}