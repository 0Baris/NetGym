using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class TrainerDetailDto : IDto
    {
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public string DealerName { get; set; }
        public decimal HourlyRate { get; set; }
        public byte IsActive { get; set; }
        
    }
}