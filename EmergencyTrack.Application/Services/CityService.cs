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
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<CityId>> Create(City entity, CancellationToken cancellationToken = default)
        {
            // TODO: принимать реквест
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<CityId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<CityId>> Delete(CityId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<CityId>(Errors.Errors.FAILURE_DELETE);

            return result.Value;
        }

        public async Task<Result<List<City>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<City>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<City>> GetById(CityId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<City>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<CityId>> Update(City entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<CityId>(Errors.Errors.FAILURE_UPDATE);

            return result.Value;
        }
    }
}
