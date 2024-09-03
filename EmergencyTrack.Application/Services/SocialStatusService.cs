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
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Services
{
    public class SocialStatusService : ISocialStatusService
    {
        private readonly ISocialStatusRepository _repository;

        public SocialStatusService(ISocialStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<SocialStatusId>> Create(SocialStatus entity, CancellationToken cancellationToken = default)
        {
            // TODO: принимать реквест
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<SocialStatusId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<SocialStatusId>> Delete(SocialStatusId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<SocialStatusId>(Errors.Errors.FAILURE_DELETE);

            return result.Value;
        }

        public async Task<Result<List<SocialStatus>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<SocialStatus>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<SocialStatus>> GetById(SocialStatusId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<SocialStatus>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<SocialStatusId>> Update(SocialStatus entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<SocialStatusId>(Errors.Errors.FAILURE_UPDATE);

            return result.Value;
        }
    }
}
