using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDealerDal : EfEntityRepositoryBase<Dealer, NetGymContext>, IDealerDal
    {
        public List<DealerDetailsDto> GetDealerDetails()
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from d in context.Dealers
                    join u in context.Users on d.UserId equals u.UserId
                    select new DealerDetailsDto
                    {
                        DealerId = d.DealerId,
                        UserId = d.UserId,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = d.CompanyName,
                        TaxNumber = d.TaxNumber,
                        CommissionRate = d.CommissionRate,
                        Region = d.Region,
                        ContractStartDate = d.ContractStartDate
                    };
                return result.ToList();
            }
        }

        public List<DealerDetailsDto> GetDealerDetailsById(int dealerId)
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from d in context.Dealers where d.DealerId == dealerId
                    join u in context.Users on d.UserId equals u.UserId
                    select new DealerDetailsDto
                    {
                        DealerId = d.DealerId,
                        UserId = d.UserId,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = d.CompanyName,
                        TaxNumber = d.TaxNumber,
                        CommissionRate = d.CommissionRate,
                        Region = d.Region,
                        ContractStartDate = d.ContractStartDate
                    };
                return result.ToList();
            }
        }
    }
}