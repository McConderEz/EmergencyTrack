using EmergencyTrack.Domain.Common;
using EmergencyTrack.Domain.Shared.Ids;
using EmergencyTrack.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Models
{
    public class SocialStatus: Entity<SocialStatusId>
    {
        private SocialStatus(SocialStatusId id) : base(id) { }

        public SocialStatus(SocialStatusId id,Status status) : base(id)
        {
            Status = status;
        }

        public Status Status { get; private set; }
    }
}
