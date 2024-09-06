using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Contracts.DTOs.AmbulanceRequest
{
    public record AddCauseOfRecallDto(AmbulanceRequestId Id, CauseOfRecall CauseOfRecall);
}
