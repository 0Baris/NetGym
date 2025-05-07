using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IDealerMemberService
    {
        IResult Add(DealerMember dealerMember);
        IResult Update(DealerMember dealerMember);
        IResult Delete(int dealerMemberId);
        IDataResult<List<DealerWithMembersDto>> GetAllWithDealers(int dealerId);
    }
}