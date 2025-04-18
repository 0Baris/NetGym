using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDealerMemberService
    {
        List<DealerMember> GetAll(int dealerId);
        DealerMember GetById(int dealerMemberId);
        void Add(DealerMember dealerMember);
        void Update(DealerMember dealerMember);
        void Delete(DealerMember dealerMember);
        
    }
}