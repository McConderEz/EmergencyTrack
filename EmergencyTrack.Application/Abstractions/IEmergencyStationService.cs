using CSharpFunctionalExtensions;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Abstractions
{
    public interface IEmergencyStationService
    {
        Task<Result<EmergencyStationId>> Create(EmergencyStation entity, CancellationToken cancellationToken = default);
        Task<Result<EmergencyStationId>> Update(EmergencyStation entity, CancellationToken cancellationToken = default);
        Task<Result<EmergencyStationId>> Delete(EmergencyStationId id, CancellationToken cancellationToken = default);
        Task<Result<EmergencyStation>> GetById(EmergencyStationId id, CancellationToken cancellationToken = default);
        Task<Result<List<EmergencyStation>>> Get(CancellationToken cancellationToken = default);
    }
}
