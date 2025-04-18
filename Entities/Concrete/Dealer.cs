using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Dealer : IEntity
    {
        public int DealerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public decimal CommissionRate { get; set; }
        public string Region { get; set; }
        public DateTime ContractStartDate { get; set; }
    }
}