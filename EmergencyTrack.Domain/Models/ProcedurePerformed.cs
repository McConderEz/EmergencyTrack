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
    public class ProcedurePerformed: Entity<ProcedurePerformedId>
    {
        private ProcedurePerformed(ProcedurePerformedId id) : base(id) { }

        public ProcedurePerformed(
            ProcedurePerformedId id,
            Price price,
            IEnumerable<Procedure> procedures,
            AmbulanceRequestId ambulanceRequestId, 
            AmbulanceRequest ambulanceRequest) : base(id)
        {
            Price = price;
            Procedures = procedures.ToList() ?? [];
            AmbulanceRequestId = ambulanceRequestId;
            AmbulanceRequest = ambulanceRequest;
        }

        public Price Price { get; private set; }
        public List<Procedure> Procedures { get; set; } = [];
        public AmbulanceRequestId AmbulanceRequestId { get; private set; }
        public AmbulanceRequest? AmbulanceRequest { get; private set; }
    }
}
