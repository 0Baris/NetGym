using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Campaign : IEntity
    {
        public int CampaignId { get; set; }
        public int TargetDealerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercentage { get; set; }
        public byte IsActive { get; set; }
    }
}