using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class SubscriptionDetailDto : IDto
    {
        public int SubscriptionId { get; set; }
        public string MemberName { get; set; }
        public string PackageName { get; set; }
        public decimal PackagePrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public byte AutoRenew { get; set; }
    }
}