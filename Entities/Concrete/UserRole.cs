using Core.Entities;

namespace Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}