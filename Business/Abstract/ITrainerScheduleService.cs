using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITrainerScheduleService
    {
        IResult Add(TrainerSchedule trainerSchedule);
        IResult Update(TrainerSchedule trainerSchedule);
        IResult Delete(int trainerScheduleId);
        IDataResult<List<TrainerSchedule>> GetList();
    }
}