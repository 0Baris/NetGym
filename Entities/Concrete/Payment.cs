using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
    }
}