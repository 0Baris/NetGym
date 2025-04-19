using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class MemberCampaignDetailDto: IDto
    {
        public int MemberCampaignId { get; set; }
        public string MemberName { get; set; }
        public string CampaignName { get; set; }
        public DateTime RedeemedDate { get; set; }
        public decimal DiscountApplied { get; set; }
    }
}