using System;
using Core.Entities.Concrete;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
    
    
}