using Microsoft.EntityFrameworkCore;
using XBuddy.Domain.Entities;
using XBuddy.Infra.SqlServer.EntityConfigurations;
using XBuddyModels.Helpers;

namespace XBuddy.Infra.SqlServer.Context
{
    public class XBuddyDbContext(DbContextOptions<XBuddyDbContext> options,
        GetTenantIdDelegate getTenantIdDelegate,
        IServiceProvider serviceProvider
        ) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TweetEntity> Tweets { get; set; }
        public DbSet<LikeEntity> Likes { get; set; }
        public DbSet<FollowEntity> Follows { get; set; }
        public DbSet<AuditLogEntity> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("xb");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<>).Assembly);
            //var userId=Guid.Parse(getTenantIdDelegate(serviceProvider));
            //modelBuilder.Entity<UserEntity>().HasQueryFilter(x => x.Id == userId));

            base.OnModelCreating(modelBuilder);
        }
    }
}
