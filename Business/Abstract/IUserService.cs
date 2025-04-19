using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(int userId); 
        IDataResult<User> GetById(int userId);
        IDataResult <List<User>> GetAll();
    }
}