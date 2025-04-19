using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTrainerDal : EfEntityRepositoryBase<Trainer, NetGymContext>, ITrainerDal
    {
        public List<TrainerDetailDto> GetTrainerDetails()
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from t in context.Trainers
                    join u in context.Users on t.UserId equals u.UserId
                    join d in context.Dealers on t.DealerId equals d.DealerId
                    select new TrainerDetailDto
                    {
                        TrainerId = t.TrainerId,
                        TrainerName = $"{u.FirstName} {u.LastName}",
                        Email = u.Email,
                        PhoneNumber = u.PhoneNumber,
                        Specialization = t.Specialization,
                        DealerName = d.CompanyName,
                        HourlyRate = t.HourlyRate,
                        IsActive = t.IsActive
                    };
                return result.ToList();
            }
        }
        
    }
}