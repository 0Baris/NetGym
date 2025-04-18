using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class MemberCampaign : IEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int CampaignId { get; set; }
        public DateTime RedeemedDate { get; set; }
        public decimal DiscountApplied { get; set; }
    }
}