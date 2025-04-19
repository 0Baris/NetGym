using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPackageService
    {
        IDataResult <Package> GetById(int packageId);
        IDataResult <List<Package>> GetAll();    
        IResult Add(Package package);
        IResult Update(Package package);
        IResult Delete(int packageId);
    }
}