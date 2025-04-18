using Microsoft.EntityFrameworkCore;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class NetGymContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NetGym;Trusted_Connection=true");
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<DealerMember> DealerMembers { get; set; }
        public DbSet<GymAccessLog> GymAccessLogs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberCampaign> MemberCampaigns { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerAssignment> TrainerAssignments { get; set; }
        public DbSet<TrainerSchedule> TrainerSchedules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        
        // public DbSet<GymCapacity> GymCapacity { get; set; }
        
    }
}