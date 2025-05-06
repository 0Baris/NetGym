using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<Role> GetRoles(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}