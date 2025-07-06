using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Domain.Entities
{
    public class TenantMappingEntity : BaseEntity
    {
        public string TenantId { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
