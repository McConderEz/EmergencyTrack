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
    public class EmergencyStationService : IEmergencyStationService
    {
        private readonly IEmergencyStationRepository _repository;

        public EmergencyStationService(IEmergencyStationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<EmergencyStationId>> Create(EmergencyStation entity, CancellationToken cancellationToken = default)
        {
            // TODO: принимать реквест
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<EmergencyStationId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<EmergencyStationId>> Delete(EmergencyStationId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<EmergencyStationId>(Errors.Errors.FAILURE_DELETE);

            return result.Value;
        }

        public async Task<Result<List<EmergencyStation>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<EmergencyStation>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<EmergencyStation>> GetById(EmergencyStationId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<EmergencyStation>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<EmergencyStationId>> Update(EmergencyStation entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<EmergencyStationId>(Errors.Errors.FAILURE_UPDATE);

            return result.Value;
        }
    }
}
