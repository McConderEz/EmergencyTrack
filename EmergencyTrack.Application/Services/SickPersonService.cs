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
    public class SickPersonService : ISickPersonService
    {
        private readonly ISickPersonRepository _repository;

        public SickPersonService(ISickPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<SickPersonId>> Create(SickPerson entity, CancellationToken cancellationToken = default)
        {
            // TODO: принимать реквест
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<SickPersonId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<SickPersonId>> Delete(SickPersonId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<SickPersonId>(Errors.Errors.FAILURE_DELETE);

            return result.Value;
        }

        public async Task<Result<List<SickPerson>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<SickPerson>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<SickPerson>> GetById(SickPersonId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<SickPerson>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<SickPersonId>> Update(SickPerson entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<SickPersonId>(Errors.Errors.FAILURE_UPDATE);

            return result.Value;
        }
    }
}
