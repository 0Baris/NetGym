using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRoleService
    {
        IDataResult<Role> GetById(int roleId);
        IDataResult<List<Role>> GetAll();
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(int roleId);
    }
}