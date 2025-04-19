using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDealerMemberService
    {
        IDataResult<List<DealerMember>> GetAll(int dealerId);
        IDataResult<DealerMember> GetById(int dealerMemberId);
        IResult Add(DealerMember dealerMember);
        IResult Update(DealerMember dealerMember);
        IResult Delete(int dealerMemberId);
        
    }
}