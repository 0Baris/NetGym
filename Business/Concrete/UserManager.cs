using System.Collections.Generic;
using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(TurkishMessages.UserAdded);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(TurkishMessages.UserAdded);
        }

        public IResult Delete(int userId)
        {
            var userToDelete = _userDal.Get(u => u.UserId == userId);
            if (userToDelete == null)
            {
                return new ErrorResult(TurkishMessages.ErrorOccurred);
            }
            _userDal.Delete(userToDelete);
            return new SuccessResult(TurkishMessages.UserDeleted);
        }

        public IDataResult<User> GetById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }
        
    }
}