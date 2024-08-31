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

        public Procedure(ProcedureId id,Title title, IEnumerable<ProcedurePerformed> procedurePerformeds) : base(id)
        {
            Title = title;
            ProcedurePerformeds = procedurePerformeds.ToList() ?? [];
        }

        public Title Title { get; private set; }
        public List<ProcedurePerformed> ProcedurePerformeds { get; private set; } = [];
    } 
}
