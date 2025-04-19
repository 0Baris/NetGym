using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTrainerAssignmentDal : EfEntityRepositoryBase<TrainerAssignment, NetGymContext>, ITrainerAssignmentDal
    {
        public List<TrainerAssignmentDetailDto> GetTrainerAssignments()
        {
            using (NetGymContext context = new NetGymContext())
            {
                var result = from ta in context.TrainerAssignments
                    join t in context.Trainers on ta.TrainerId equals t.TrainerId
                    join tu in context.Users on t.UserId equals tu.UserId
                    join m in context.Members on ta.MemberId equals m.MemberId
                    join mu in context.Users on m.UserId equals mu.UserId
                    select new TrainerAssignmentDetailDto
                    {
                        AssignmentId = ta.AssignmentId,
                        TrainerName = $"{tu.FirstName} {tu.LastName}",
                        MemberName = $"{mu.FirstName} {mu.LastName}",
                        StartDate = ta.StartDate,
                        EndDate = ta.EndDate,
                        SessionCount = ta.SessionCount,
                        Notes = ta.Notes

                    };
                return result.ToList();
            }
        }
    }
}