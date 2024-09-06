using EmergencyTrack.Application.Services;
using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.EmergencyStationDtos
{
    public record AddAmbulanceRequestDto(EmergencyStationId EmergencyStationId, AmbulanceRequestService AmbulanceRequest);
}
