using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;

namespace XBuddy.Infra.SqlServer.EntityConfigurations
{
    public sealed class UserEntityConfiguration:BaseEntityConfiguration<UserEntity>
    {
        public new void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired();
            base.Configure(builder);
        }
    }
}
