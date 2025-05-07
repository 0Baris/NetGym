using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IDealerDal : IEntityRepository<Dealer>
    {
        List<DealerDetailsDto> GetDealerDetails();
        List<DealerDetailsDto> GetDealerDetailsById(int dealerId);
    }
}