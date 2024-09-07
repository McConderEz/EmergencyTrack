using CSharpFunctionalExtensions;
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
    public class CauseOfRecall: Common.Entity<CauseOfRecallId>
    {
        private CauseOfRecall(CauseOfRecallId id): base(id) { }

        public CauseOfRecall(CauseOfRecallId id, Cause cause,List<AmbulanceRequest> ambulanceRequests) : base(id)
        {
            Cause = cause;
            AmbulanceRequests = ambulanceRequests ?? [];
        }

        public Cause Cause { get; set; }
        public List<AmbulanceRequest> AmbulanceRequests { get; set; } = [];

        public Result UpdateMainInfo(Cause? cause)
        {
            Cause = cause ?? Cause;

            return Result.Success();
        }

    }
}
