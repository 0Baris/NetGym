using Core.Entities;

namespace Entities.DTOs
{
    public class RoleDto : IDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}