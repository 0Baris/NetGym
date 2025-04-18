using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class TrainerSchedule : IEntity
    {
        public int ScheduleId { get; set; }
        public int TrainerId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public byte IsRecurring { get; set; }
    }
}