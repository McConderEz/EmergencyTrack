using CSharpFunctionalExtensions;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Abstractions
{
    public interface IAmbulanceRequestService
    {
        Task<Result<AmbulanceRequestId>> Create(AmbulanceRequest entity, CancellationToken cancellationToken = default);
        Task<Result<AmbulanceRequestId>> Update(AmbulanceRequest entity, CancellationToken cancellationToken = default);
        Task<Result<AmbulanceRequestId>> Delete(AmbulanceRequestId id, CancellationToken cancellationToken = default);
        Task<Result<AmbulanceRequest>> GetById(AmbulanceRequestId id, CancellationToken cancellationToken = default);
        Task<Result<List<AmbulanceRequest>>> Get(CancellationToken cancellationToken = default);
    }
}
