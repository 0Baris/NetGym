using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class MemberDetailDto : IDto
    {
        public int MemberId { get; set; }
        public string IdentityNumber { get; set; }
        public string Notes { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string MemberName { get; set; }
        public string PhoneNumber { get; set; }
    }
}