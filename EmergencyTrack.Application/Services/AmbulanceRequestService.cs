using CSharpFunctionalExtensions;
using EmergencyTrack.Application.Abstractions;
using EmergencyTrack.Application.Repositories;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Services
{
    public class AmbulanceRequestService : IAmbulanceRequestService
    {
        //TODO: Во все сервисы добавить валидацию и добавить реквесты(Dto)

        private readonly IAmbulanceRequestRepository _repository;

        public AmbulanceRequestService(IAmbulanceRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<AmbulanceRequestId>> Create(AmbulanceRequest entity, CancellationToken cancellationToken = default)
        {
            //TODO: принимать реквест 
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<AmbulanceRequestId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<AmbulanceRequestId>> Delete(AmbulanceRequestId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<AmbulanceRequestId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<List<AmbulanceRequest>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<AmbulanceRequest>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<AmbulanceRequest>> GetById(AmbulanceRequestId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id,cancellationToken);

            if (result.IsFailure)
                return Result.Failure<AmbulanceRequest>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<AmbulanceRequestId>> Update(AmbulanceRequest entity, CancellationToken cancellationToken = default)
        {
            //TODO: добавить метод обновления в domain
            //TODO: принимать реквест 

            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<AmbulanceRequestId>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }
    }
}
