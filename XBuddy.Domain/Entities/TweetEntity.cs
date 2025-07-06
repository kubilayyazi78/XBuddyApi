using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Domain.Entities
{
    public class TweetEntity : BaseEntity
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public int ViewCount { get; set; }
        public UserEntity User { get; set; }
        public ICollection<LikeEntity> Likes { get; set; }
    }
}
