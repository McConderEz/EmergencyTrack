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
    public class Procedure: Entity<ProcedureId>
    {
        private Procedure(ProcedureId id): base(id) { }

        public Title Title { get; private set; }
    }
}
