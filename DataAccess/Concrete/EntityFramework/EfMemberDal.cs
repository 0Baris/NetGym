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
        public List<MemberDetailDto> GetMemberDetail()
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
    }
}