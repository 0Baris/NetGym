using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,NetGymContext>,IUserDal
    {
        public List<Role> GetRoles(User user)
        {
            using (var context = new NetGymContext())
            {
                var result = from role in context.Roles
                    join userRole in context.UserRoles
                        on role.RoleId equals userRole.RoleId
                    where userRole.UserId == user.UserId
                    select new Role 
                        {
                            RoleId = role.RoleId,
                            RoleName = role.RoleName
                        };
                return result.ToList();
            }
        }
    }
}