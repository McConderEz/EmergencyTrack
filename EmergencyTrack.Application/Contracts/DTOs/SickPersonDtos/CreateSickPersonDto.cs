using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using EmergencyTrack.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.SickPersonDtos
{
    public record CreateSickPersonDto(
            FullName fullName,
            BirthDate birthDate,
            SocialStatusId socialStatusId,
            SocialStatus socialStatus,
            PhoneNumber phoneNumber,
            Address address);
}
