using EmergencyTrack.Domain.Shared.Ids;
using EmergencyTrack.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.ProcedureDtos
{
    public record UpdateProcedureDto(ProcedureId ProcedureId, Title Title);
}
