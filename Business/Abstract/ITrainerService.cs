using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ITrainerService
    {
        IResult Add(Trainer trainer);
        IResult Update(Trainer trainer);
        IResult Delete(int trainerId);
        IDataResult<List<Trainer>> GetAll();
        IDataResult<Trainer> GetById(int trainerId);
        IDataResult<List<TrainerDetailDto>> GetTrainerDetails();
        IDataResult<TrainerDetailDto> GetTrainerDetailsById(int trainerId);
        
    }
}