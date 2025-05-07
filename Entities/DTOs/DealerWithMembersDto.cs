using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class DealerWithMembers : IDto
    {
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerPhoneNumber { get; set; }
        public string DealerEmail { get; set; }
        public string DealerAddress { get; set; }
        public string MemberName { get; set; }
        public string MemberPhoneNumber { get; set; }
        public string MemberEmail { get; set; }
        public string MemberIdentityNumber { get; set; }
        public DateTime MemberBirthDate { get; set; }
        public DateTime MemberRegistrationDate { get; set; }
    }
}