using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constants.Messages;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PackageManager : IPackageService
    {
        IPackageDal _packageDal;
        
        public PackageManager(IPackageDal packageDal)
        {
            _packageDal = packageDal;
        }
        
        public IDataResult<Package> GetById(int packageId)
        {
            return new SuccessDataResult<Package>(_packageDal.Get(p => p.PackageId == packageId), TurkishMessages.Success);
        }

        public IDataResult<List<Package>> GetAll()
        {
            return new SuccessDataResult<List<Package>>(_packageDal.GetAll(), TurkishMessages.Success);
        }

        [ValidationAspect(typeof(PackageValidator))]
        public IResult Add(Package package)
        {
            
            var result = BusinessRules.Run(CheckIfPackageExists(package.Name));
            
            if (result != null)
            {
                return result;
            }
            
            _packageDal.Add(package);
            return new SuccessResult(TurkishMessages.PackageAdded);
            
        }

        [ValidationAspect(typeof(PackageValidator))]
        public IResult Update(Package package)
        {
            var result = BusinessRules.Run(CheckIfPackageExists(package.Name));
            
            if (result != null)
            {
                return result;
            }
            
            _packageDal.Update(package);
            
            return new SuccessResult(TurkishMessages.PackageUpdated);
        }

        public IResult Delete(int packageId)
        {
            var result = BusinessRules.ValidateEntityExistence(_packageDal, packageId,p => p.PackageId == packageId);
            
            if (result != null)
            {
                return result;
            }
            var packageToDelete = _packageDal.Get(p => p.PackageId == packageId);
            _packageDal.Delete(packageToDelete);
            return new SuccessResult(TurkishMessages.PackageDeleted);
            
        }
        
        private IResult CheckIfPackageExists(string packageName)
        {
            var result = _packageDal.Get(p => p.Name == packageName);
            if (result != null)
            {
                return new ErrorResult(TurkishMessages.NameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}