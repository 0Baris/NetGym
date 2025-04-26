using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constants.Messages;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        
        IRoleDal _roleDal;
        
        public RoleManager(IRoleDal roleDal) { 
            _roleDal = roleDal;
        }
        
        public IDataResult<Role> GetById(int roleId)
        {
            return new SuccessDataResult<Role>(_roleDal.Get(p => p.RoleId == roleId));
        }

        public IDataResult<List<Role>> GetAll()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetAll());
        }

        [ValidationAspect(typeof(RoleValidator))]
        public IResult Add(Role role)
        {
            var result = BusinessRules.Run(CheckIfRoleExists(role.RoleName));
            
            if (result != null)
            {
                return result;
            }
            
            _roleDal.Add(role);
            return new SuccessResult(TurkishMessages.RoleAdded);
        }
        
        [ValidationAspect(typeof(RoleValidator))]
        public IResult Update(Role role)
        {
            var result = BusinessRules.Run(CheckIfRoleExists(role.RoleName));
            
            if (result != null)
            {
                return result;
            }
            _roleDal.Update(role);
            return new SuccessResult(TurkishMessages.RoleUpdated);
        }

        public IResult Delete(int roleId)
        {
            var result = BusinessRules.ValidateEntityExistence(_roleDal,roleId,p => p.RoleId == roleId);
            
            if (result != null)
            {
                return result;
            }
            var role = _roleDal.Get(r => r.RoleId == roleId);
            _roleDal.Delete(role);
            return new SuccessResult(TurkishMessages.RoleDeleted);
            
        }

        private IResult CheckIfRoleExists(string roleName)
        {
            var result = _roleDal.Get(r => r.RoleName == roleName);
            if (result != null)
            {
                return new ErrorResult("Role already exists");
            }

            return new SuccessResult();

        }
    }
}