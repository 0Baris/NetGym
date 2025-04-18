using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(int userId);
        User GetById(int userId);
        List<User> GetAll();
    }
}