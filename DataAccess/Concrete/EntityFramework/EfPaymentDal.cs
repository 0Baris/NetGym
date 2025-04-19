using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, NetGymContext>, IPaymentDal
    {

        public List<PaymentDetailDto> GetPaymentDetails()
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from p in context.Payments
                             join s in context.Subscriptions on p.SubscriptionId equals s.SubscriptionId
                             join m in context.Members on s.MemberId equals m.MemberId
                             join mu in context.Users on m.UserId equals mu.UserId
                             join pkg in context.Packages on s.PackageId equals pkg.PackageId
                             select new PaymentDetailDto
                             {
                                 PaymentId = p.PaymentId,
                                 SubscriptionId = s.SubscriptionId,
                                 MemberName = mu.FirstName + " " + mu.LastName,
                                 PackageName = pkg.Name,
                                 Amount = p.Amount,
                                 PaymentDate = p.PaymentDate,
                                 PaymentMethod = p.PaymentMethod,
                                 TransactionId = p.TransactionId,
                                 Status = p.Status
                             };
                return result.ToList();
            }
        }
        
        
    }
}