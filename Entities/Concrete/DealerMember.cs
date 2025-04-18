using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class DealerMember : IEntity
    {
        public int  Id { get; set; }
        public int  DealerId { get; set; }
        public int  MemberId { get; set; }
        public DateTime  RegistrationDate { get; set; }
    }
}