using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class TrainerManager : ITrainerService
    {
        ITrainerDal _trainerDal;
        
        public TrainerManager(ITrainerDal trainerDal)
        {
            _trainerDal = trainerDal;
        }
        
        public IResult Add(Trainer trainer)
        {
            _trainerDal.Add(trainer);
            return new SuccessResult(TurkishMessages.TrainerAdded);
        }

        public IResult Update(Trainer trainer)
        {
            _trainerDal.Update(trainer);
            return new SuccessResult(TurkishMessages.TrainerUpdated);
        }

        public IResult Delete(int trainerId)
        {
            var trainerToDelete = _trainerDal.Get(t=> t.TrainerId == trainerId);
            if (trainerToDelete == null)
            {
                return new ErrorResult(TurkishMessages.ErrorOccurred);
            }
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
            throw new System.NotImplementedException();
        }
    }
}