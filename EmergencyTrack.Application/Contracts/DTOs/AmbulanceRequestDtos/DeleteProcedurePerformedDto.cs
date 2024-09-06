﻿using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.AmbulanceRequestDtos
{
    public record DeleteProcedurePerformedDto(AmbulanceRequestId AmbulanceRequestId, ProcedurePerformedId ProcedurePerformedId);
}