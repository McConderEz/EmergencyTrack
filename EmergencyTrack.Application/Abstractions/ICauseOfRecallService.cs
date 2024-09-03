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
    public interface ICauseOfRecallService
    {
        Task<Result<CauseOfRecallId>> Create(CauseOfRecall entity, CancellationToken cancellationToken = default);
        Task<Result<CauseOfRecallId>> Update(CauseOfRecall entity, CancellationToken cancellationToken = default);
        Task<Result<CauseOfRecallId>> Delete(CauseOfRecallId id, CancellationToken cancellationToken = default);
        Task<Result<CauseOfRecall>> GetById(CauseOfRecallId id, CancellationToken cancellationToken = default);
        Task<Result<List<CauseOfRecall>>> Get(CancellationToken cancellationToken = default);
    }
}
