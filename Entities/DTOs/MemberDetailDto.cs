using System;

namespace Entities.DTOs
{
    public class MemberDetailDto
    {
        public int MemberId { get; set; }
        public string IdentityNumber { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        // User tarafından gelen bilgiler
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}