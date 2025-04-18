using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserDto : IDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}