using CSharpFunctionalExtensions;
using EmergencyTrack.Application.Abstractions;
using EmergencyTrack.Application.Repositories;
using EmergencyTrack.Domain.Common;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Services
{
    public class CauseOfRecallService : ICauseOfRecallService
    {
        private readonly ICauseOfRecallRepository _repository;

        public CauseOfRecallService(ICauseOfRecallRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<CauseOfRecallId>> Create(CauseOfRecall entity, CancellationToken cancellationToken = default)
        {
            // TODO: принимать реквест
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<CauseOfRecallId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<CauseOfRecallId>> Delete(CauseOfRecallId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<CauseOfRecallId>(Errors.Errors.FAILURE_DELETE);

            return result.Value;
        }

        public async Task<Result<List<CauseOfRecall>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<CauseOfRecall>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<CauseOfRecall>> GetById(CauseOfRecallId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<CauseOfRecall>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<CauseOfRecallId>> Update(CauseOfRecall entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<CauseOfRecallId>(Errors.Errors.FAILURE_UPDATE);

            return result.Value;
        }
    }
}
