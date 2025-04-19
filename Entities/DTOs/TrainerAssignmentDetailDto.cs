using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class TrainerAssignmentDetailDto : IDto
    {
        public int AssignmentId { get; set; }
        public string TrainerName { get; set; }
        public string MemberName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SessionCount { get; set; }
        public string Notes { get; set; }
    }
}