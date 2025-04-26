using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constants.Messages;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(
                CheckIfUserPhoneNumberExists(user.PhoneNumber));
            
            if (result != null)
            {
                return result;
            }
            
            _userDal.Add(user);
            
            return new SuccessResult(TurkishMessages.UserAdded);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            IResult result = BusinessRules.Run(
                CheckIfUserPhoneNumberExists(user.PhoneNumber));
            
            if (result != null)
            {
                return result;
            }
            
            _userDal.Update(user);
            return new SuccessResult(TurkishMessages.UserUpdated);
        }

        public IResult Delete(int userId)
        {
            var result = BusinessRules.ValidateEntityExistence(_userDal, userId, u => u.UserId == userId);
            
            if (result != null)
            {
                return result;
            }
            
            var userToDelete = _userDal.Get(u => u.UserId == userId);
            _userDal.Delete(userToDelete);
            
            return new SuccessResult(TurkishMessages.UserDeleted);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId), TurkishMessages.Success);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), TurkishMessages.Success);
        }
        
        private IResult CheckIfUserPhoneNumberExists(string phoneNumber)
        {
            var result = _userDal.Get(u => u.PhoneNumber == phoneNumber);
            if (result != null)
            {
                return new ErrorResult(TurkishMessages.UserPhoneNumberAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}