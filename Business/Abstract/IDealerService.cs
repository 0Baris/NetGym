using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IDealerService
    {
        IDataResult<List<Dealer>> GetAll();
        IDataResult<Dealer>  GetById(int dealerId);
        IDataResult<Dealer>  GetByRegion(string region);
        IResult Add(Dealer dealer);
        IResult Update(Dealer dealer);
        IResult Delete(int dealerId);
        IDataResult<List<DealerDetailsDto>> GetDealerDetails();
        IDataResult<List<DealerDetailsDto>> GetDealerDetailsById(int dealerId);
        
    }
}