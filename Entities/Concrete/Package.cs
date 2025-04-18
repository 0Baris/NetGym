using Core.Entities;

namespace Entities.Concrete
{
    public class Package : IEntity
    {
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public byte IsActive { get; set; }
    }
}