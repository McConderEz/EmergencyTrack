using EmergencyTrack.Domain.Common;
using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Models
{
    public class CauseOfRecall: Entity<CauseOfRecallId>
    {
        private CauseOfRecall(CauseOfRecallId id): base(id) { }

        public string Cause { get; set; }

    }
}
