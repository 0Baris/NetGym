using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMemberService
    {
        List<Member> GetAll();
        Member GetById(int id);
        void Add(Member member);
        void Update(Member member);
        void Delete(int id);
    }
}