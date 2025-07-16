﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBuddy.Domain.Entities;

namespace XBuddy.Infra.SqlServer.EntityConfigurations
{
    public sealed class FollowEntityConfiguration : BaseEntityConfiguration<FollowEntity>
    {
        public new void Configure(EntityTypeBuilder<FollowEntity> builder)
        {

            builder.Property(x => x.FollowerUserId).IsRequired();
            builder.Property(x => x.FollowingUserId).IsRequired();

            builder.HasOne(x => x.FollowerUser)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.FollowerUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.FollowingUser)
                .WithMany(x => x.Followings)
                .HasForeignKey(x => x.FollowingUserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
