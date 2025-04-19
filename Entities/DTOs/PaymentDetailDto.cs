using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class PaymentDetailDto : IDto
    {
        public int PaymentId { get; set; }
        public int SubscriptionId { get; set; }
        public string MemberName { get; set; }
        public string PackageName { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
    }
}