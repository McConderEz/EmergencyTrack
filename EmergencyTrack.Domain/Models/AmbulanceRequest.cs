using EmergencyTrack.Domain.Common;
using EmergencyTrack.Domain.Shared.Ids;
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

        public DateTime RequestDateTime { get; set; }
        public List<CauseOfRecall> CauseOfRecalls { get; set; } = [];
        public List<ProcedurePerformed> ProcedurePerformeds { get; set; } = [];
        public SickPersonId SickPersonId { get; set; }
        public SickPerson? SickPerson { get; set; }


    }
}
