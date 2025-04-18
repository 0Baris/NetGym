using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Subscription : IEntity
    {
        public int SubscriptionId { get; set; }
        public int MemberId { get; set; }
        public int PackageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte AutoRenew { get; set; }
        public string Status { get; set; }
    }
}