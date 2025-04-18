using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPackageService
    {
        Package GetById(int packageId);
        List<Package> GetAll();    
        void Add(Package package);
        void Update(Package package);
        void Delete(int packageId);
    }
}