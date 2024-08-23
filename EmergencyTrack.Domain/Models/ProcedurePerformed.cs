using EmergencyTrack.Domain.Common;
using EmergencyTrack.Domain.Shared.Ids;
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

        public decimal Price { get; set; }
        public List<Procedure> Procedures { get; set; } = [];
    }
}
