using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class TrainerManager : ITrainerService
    {
        private readonly ITrainerDal _trainerDal;
        private readonly IUserDal _userDal;
        
        public TrainerManager(ITrainerDal trainerDal, IUserDal userDal)
        {
            _trainerDal = trainerDal;
            _userDal = userDal;
        }
        
        [SecuredOperation("admin,dealer.admin")]
        [ValidationAspect(typeof(TrainerValidator))]
        public IResult Add(Trainer trainer)
        {
            IResult result = BusinessRules.Run(
                CheckIfTrainerExists(trainer.UserId));
            
            if (result != null)
            {
                return result;
            }
            
            _trainerDal.Add(trainer);
            return new SuccessResult(TurkishMessages.TrainerAdded);
        }

        [SecuredOperation("admin,dealer.admin")]
        [ValidationAspect(typeof(TrainerValidator))]
        public IResult Update(Trainer trainer)
        {
            IResult result = BusinessRules.Run(
                CheckIfTrainerExists(trainer.UserId));
            
            if (result != null)
            {
                return result;
            }

            _trainerDal.Update(trainer);
            return new SuccessResult(TurkishMessages.TrainerUpdated);
        }

        [SecuredOperation("admin,dealer.admin")]
        public IResult Delete(int trainerId)
        {
            var result = BusinessRules.ValidateEntityExistence(
                _trainerDal, trainerId, t => t.TrainerId == trainerId);
            
            if (result != null)
            {
                return result;
            }
            
            var trainerToDelete = _trainerDal.Get(t=> t.TrainerId == trainerId);
            _trainerDal.Delete(trainerToDelete);
            
            return new SuccessResult(TurkishMessages.TrainerDeleted);
        }

        public IDataResult<List<Trainer>> GetAll()
        {
            return new SuccessDataResult<List<Trainer>>(_trainerDal.GetAll());
        }

        public IDataResult<List<TrainerDetailDto>> GetTrainerDetails()
        {
            return new SuccessDataResult<List<TrainerDetailDto>>(_trainerDal.GetTrainerDetails(), TurkishMessages.Success);
        }

        public IDataResult<Trainer> GetById(int trainerId)
        {
            return new SuccessDataResult<Trainer>(_trainerDal.Get(u => u.TrainerId == trainerId));
        }

        public IDataResult<TrainerDetailDto> GetTrainerDetailsById(int trainerId)
        {
            var result = _trainerDal.GetTrainerDetails().FirstOrDefault(t => t.TrainerId == trainerId);
            if (result == null)
            {
                return new ErrorDataResult<TrainerDetailDto>(TurkishMessages.ErrorOccurred);
            }

            return new SuccessDataResult<TrainerDetailDto>(result, TurkishMessages.Success);
        }
        

        private IResult CheckIfTrainerExists(int userId)
        {
            var user = _userDal.Get(u => u.UserId == userId);

            if (user != null)
            {
                var trainer = _trainerDal.Get(t => t.UserId == user.UserId);

                if (trainer != null && !string.IsNullOrEmpty(user.PhoneNumber))
                {
                    return new ErrorResult(TurkishMessages.TrainerAlreadyExists);
                }
            }

            return new SuccessResult();
        }
    }
}