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
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _repository;

        public DistrictService(IDistrictRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<DistrictId>> Create(District entity, CancellationToken cancellationToken = default)
        {
            // TODO: принимать реквест
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<DistrictId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<DistrictId>> Delete(DistrictId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<DistrictId>(Errors.Errors.FAILURE_DELETE);

            return result.Value;
        }

        public async Task<Result<List<District>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<District>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<District>> GetById(DistrictId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<District>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<DistrictId>> Update(District entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<DistrictId>(Errors.Errors.FAILURE_UPDATE);

            return result.Value;
        }
    }
}
