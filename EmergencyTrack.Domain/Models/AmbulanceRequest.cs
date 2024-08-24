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
    public class AmbulanceRequest: Entity<AmbulanceRequestId>
    {
        private AmbulanceRequest(AmbulanceRequestId id): base(id) { }

        public RequestDateTime RequestDateTime { get; private set; }
        public List<CauseOfRecall> CauseOfRecalls { get; set; } = [];
        public List<ProcedurePerformed> ProcedurePerformeds { get; set; } = [];
        public SickPersonId SickPersonId { get; private set; }
        public SickPerson? SickPerson { get; private set; }


    }
}
