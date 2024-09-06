using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using EmergencyTrack.Domain.Shared.ValueObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.CauseOfRecallDtos
{
    public record UpdateCauseOfRecallDto(CauseOfRecallId Id, Cause Cause, AmbulanceRequestId ambulanceRequestId, Domain.Models.AmbulanceRequest AmbulanceRequest);
}
