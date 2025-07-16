using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;
namespace XBuddy.Infra.SqlServer.EntityConfigurations
{
    public sealed class TenantMappingEntityConfiguration : BaseEntityConfiguration<TenantMappingEntity>
    {
        public new void Configure(EntityTypeBuilder<TenantMappingEntity> builder)
        {
            builder.Property(x => x.TenantId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.User)
                .WithOne(x => x.TenantMapping)
                .HasForeignKey<TenantMappingEntity>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
