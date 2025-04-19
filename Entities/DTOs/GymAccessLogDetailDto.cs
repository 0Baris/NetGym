using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class GymAccessLogDetailDto : IDto
    {
        public int LogId { get; set; }
        public string MemberName { get; set; }
        public string DealerName { get; set; }
        public string TrainerName { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public string AccessType { get; set; }
        public int DurationMinutes { get; set; }
    }
}