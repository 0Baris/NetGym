using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IMemberService
    {
        IDataResult<List<Member>> GetAll();
        IDataResult<List<Member>> GetAllByDetails();
        IDataResult<List<MemberDetailDto>> GetMemberDetails();
        IDataResult<Member> GetById(int id);
        IResult Add(Member member);
        IResult Update(Member member);
        IResult Delete(int id);
    }
}