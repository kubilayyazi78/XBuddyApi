using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Domain.Entities
{
    public class LikeEntity:BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }
        public UserEntity User { get; set; }
        public TweetEntity Tweet { get; set; }
    }
}
