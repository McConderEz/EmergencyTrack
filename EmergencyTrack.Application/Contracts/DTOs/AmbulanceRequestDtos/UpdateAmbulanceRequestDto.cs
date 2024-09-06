using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using EmergencyTrack.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.AmbulanceRequest
{
    public record UpdateAmbulanceRequestDto(
            AmbulanceRequestId AmbulanceRequestId,
            RequestDateTime? RequestDateTime,
            SickPersonId? SickPersonId,
            SickPerson? SickPerson,
            EmergencyStationId? EmergencyStationId,
            EmergencyStation? EmergencyStation);
}
