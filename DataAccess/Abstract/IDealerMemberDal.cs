using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IDealerMemberDal : IEntityRepository<DealerMember>
    {
        List<DealerWithMembersDto> GetDealerWithMembers(int dealerId);
    }
}