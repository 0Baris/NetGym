using System;

namespace Entities.DTOs
{
    public class TrainerDetailDto
    {
        public int TrainerId { get; set; }
        public int UserId { get; set; }
        public int DealerId { get; set; }
        
        // User tarafından gelen bilgiler
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string Specialization { get; set; }
        public string CertificationNumber { get; set; }
        public string Bio { get; set; }
        public decimal HourlyRate { get; set; }
        public byte IsActive { get; set; }
        
        // Schedule tarafından gelen bilgiler
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        
    }
}