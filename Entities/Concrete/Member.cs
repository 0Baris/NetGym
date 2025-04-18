using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Member : IEntity
    {
        public int MemberId { get; set; }
        public int UserId { get; set; }
        
        public string IdentityNumber { get; set; }
        public string Notes { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}