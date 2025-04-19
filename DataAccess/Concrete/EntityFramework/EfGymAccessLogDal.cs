using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGymAccessLogDal : EfEntityRepositoryBase<GymAccessLog, NetGymContext>, IGymAccessLogDal
    {
        public List<GymAccessLogDetailDto> GetLogsWithDetails()
        {
            using (var context = new NetGymContext())
            {
                var result = from log in context.GymAccessLogs
                             join m in context.Members on log.MemberId equals m.MemberId
                             join mu in context.Users on m.UserId equals mu.UserId
                             join d in context.Dealers on log.DealerId equals d.DealerId
                             join t in context.Trainers on log.TrainerId equals t.TrainerId
                             join tu in context.Users on t.UserId equals tu.UserId
                             select new GymAccessLogDetailDto()
                             {
                                    LogId = log.LogId,
                                    MemberName = $"{mu.FirstName} {mu.LastName}",
                                    DealerName = d.CompanyName,
                                    TrainerName = $"{tu.FirstName} {tu.LastName}",
                                    CheckInTime = log.CheckInTime,
                                    CheckOutTime = log.CheckOutTime,
                                    AccessType = log.AccessType,
                                    DurationMinutes = log.DurationMinutes
                             };
                return result.ToList();
            }
        }
    }
}