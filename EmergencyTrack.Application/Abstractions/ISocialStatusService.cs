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
    public interface ISocialStatusService
    {
        Task<Result<SocialStatusId>> Create(SocialStatus entity, CancellationToken cancellationToken = default);
        Task<Result<SocialStatusId>> Update(SocialStatus entity, CancellationToken cancellationToken = default);
        Task<Result<SocialStatusId>> Delete(SocialStatusId id, CancellationToken cancellationToken = default);
        Task<Result<SocialStatus>> GetById(SocialStatusId id, CancellationToken cancellationToken = default);
        Task<Result<List<SocialStatus>>> Get(CancellationToken cancellationToken = default);
    }
}
