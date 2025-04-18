using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRoleService
    {
        Role GetById(int roleId);
        List<Role> GetAll();
        void Add(Role role);
        void Update(Role role);
        void Delete(int roleId);
        List<Role> GetRolesByUserId(int userId);
    }
}