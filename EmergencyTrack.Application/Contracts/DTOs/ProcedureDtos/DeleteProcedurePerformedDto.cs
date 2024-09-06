using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.ProcedureDtos
{
    public record DeleteProcedurePerformedDto(ProcedureId ProcedureId, ProcedurePerformedId ProcedurePerformedId);
}
