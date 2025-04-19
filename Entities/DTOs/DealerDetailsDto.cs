using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class DealerDetailsDto : IDto
    {
        public int DealerId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public decimal CommissionRate { get; set; }
        public string Region { get; set; }
        public DateTime ContractStartDate { get; set; }
        
    }
}