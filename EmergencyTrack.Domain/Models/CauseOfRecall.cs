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
    public class CauseOfRecall: Entity<CauseOfRecallId>
    {
        private CauseOfRecall(CauseOfRecallId id): base(id) { }

        public CauseOfRecall(CauseOfRecallId id, Cause cause, AmbulanceRequestId ambulanceRequestId, AmbulanceRequest ambulanceRequest) : base(id)
        {
            Cause = cause;
            AmbulanceRequestId = ambulanceRequestId;
            AmbulanceRequest = ambulanceRequest;
        }

        public Cause Cause { get; private set; }
        public AmbulanceRequestId AmbulanceRequestId { get; private set; }
        public AmbulanceRequest? AmbulanceRequest { get; private set; }

    }
}
