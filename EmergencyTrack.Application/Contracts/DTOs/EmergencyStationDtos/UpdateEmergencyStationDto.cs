using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using EmergencyTrack.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.EmergencyStationDtos
{
    public record UpdateEmergencyStationDto(
        EmergencyStationId EmergencyStationId,
        StationNumber StationNumber,
        DistrictId DistrictId,
        District District,
        PhoneNumber PhoneNumber,
        Address Address);
}
