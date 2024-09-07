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
    public class Procedure: Common.Entity<ProcedureId>
    {
        private Procedure(ProcedureId id): base(id) { }

        public Procedure(ProcedureId id,Title title, List<ProcedurePerformed> procedurePerformeds) : base(id)
        {
            Title = title;
            ProcedurePerformeds = procedurePerformeds ?? [];
        }

        public Title Title { get; set; }
        public List<ProcedurePerformed> ProcedurePerformeds { get; set; } = [];

        public Result UpdateMainInfo(Title? title)
        {
            Title = title ?? Title;

            return Result.Success();
        }

        public void AddProcedurePerformed(ProcedurePerformed procedurePerformed) => ProcedurePerformeds.Add(procedurePerformed);
        public void RemoveProcedurePerformed(ProcedurePerformed procedurePerformed) => ProcedurePerformeds.Remove(procedurePerformed);
    } 
}
