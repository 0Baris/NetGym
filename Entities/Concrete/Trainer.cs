using Core.Entities;

namespace Entities.Concrete
{
    public class Trainer : IEntity
    {
        public int TrainerId { get; set; }
        public int UserId { get; set; }
        public int DealerId { get; set; }
        public string Specialization { get; set; }
        public string CertificationNumber { get; set; }
        public string Bio { get; set; }
        public decimal HourlyRate { get; set; }
        public byte IsActive { get; set; }
    }
}