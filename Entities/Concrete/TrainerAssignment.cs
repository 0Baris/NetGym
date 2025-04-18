using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class TrainerAssignment : IEntity
    {
        public int AssignmentId { get; set; }
        public int TrainerId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SessionCount { get; set; }
        public string Notes { get; set; }

    }
}