using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITrainerScheduleService
    {
        void Add(TrainerSchedule trainerSchedule);
        void Update(TrainerSchedule trainerSchedule);
        void Delete(int trainerScheduleId);
        List<TrainerSchedule> GetList();
    }
}