using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Domain.Entities
{
    public class FollowEntity : BaseEntity
    {
        public Guid FollowerUserId { get; set; }
        public Guid FollowingUserId { get; set; }
        public UserEntity FollowerUser { get; set; }
        public UserEntity FollowingUser { get; set; }
    }
}
