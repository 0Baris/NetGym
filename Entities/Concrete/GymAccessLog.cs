using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class GymAccessLog : IEntity
    {
        public int LogId { get; set; }
        public int MemberId { get; set; }
        public int DealerId { get; set; }
        public int TrainerId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public string AccessType { get; set; }
        public int DurationMinutes { get; set; }
    }
}