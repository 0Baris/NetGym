using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class MemberCampaignDto : IDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int CampaignId { get; set; }
        public DateTime RedeemedDate { get; set; }
        public decimal DiscountApplied { get; set; }
    }
}