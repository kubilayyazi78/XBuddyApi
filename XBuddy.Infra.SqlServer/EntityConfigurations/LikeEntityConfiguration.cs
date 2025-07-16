using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;

namespace XBuddy.Infra.SqlServer.EntityConfigurations
{
    public sealed class LikeEntityConfiguration:BaseEntityConfiguration<LikeEntity>
    {
        public new void Configure(EntityTypeBuilder<LikeEntity> builder)
        {
            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.TweetId).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Tweet)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.TweetId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
