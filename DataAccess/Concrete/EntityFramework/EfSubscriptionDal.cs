using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSubscriptionDal : EfEntityRepositoryBase<Subscription, NetGymContext>, ISubscriptionDal
    {
        
        public List<SubscriptionDetailDto> GetSubscriptionDetails()
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from s in context.Subscriptions
                             join m in context.Members on s.MemberId equals m.MemberId
                             join mu in context.Users on m.UserId equals mu.UserId
                             join p in context.Packages on s.PackageId equals p.PackageId
                             select new SubscriptionDetailDto
                             {
                                 SubscriptionId = s.SubscriptionId,
                                 MemberName = mu.FirstName + " " + mu.LastName,
                                 PackageName = p.Name,
                                 PackagePrice = p.Price,
                                 StartDate = s.StartDate,
                                 EndDate = s.EndDate,
                                 Status = s.Status,
                                 AutoRenew = s.AutoRenew
                             };
                return result.ToList();
            }
        }
        
        public List<SubscriptionDetailDto> GetSubscriptionDetailById(int subscriptionId)
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from s in context.Subscriptions
                             join m in context.Members on s.MemberId equals m.MemberId
                             join mu in context.Users on m.UserId equals mu.UserId
                             join p in context.Packages on s.PackageId equals p.PackageId
                             where s.SubscriptionId == subscriptionId
                             select new SubscriptionDetailDto
                             {
                                 SubscriptionId = s.SubscriptionId,
                                 MemberName = mu.FirstName + " " + mu.LastName,
                                 PackageName = p.Name,
                                 PackagePrice = p.Price,
                                 StartDate = s.StartDate,
                                 EndDate = s.EndDate,
                                 Status = s.Status,
                                 AutoRenew = s.AutoRenew
                             };
                return result.ToList();
            }
        }
        
    }
}