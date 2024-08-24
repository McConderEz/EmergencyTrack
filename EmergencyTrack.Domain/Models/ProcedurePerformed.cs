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

        public Price Price { get; private set; }
        public List<Procedure> Procedures { get; set; } = [];
    }
}
