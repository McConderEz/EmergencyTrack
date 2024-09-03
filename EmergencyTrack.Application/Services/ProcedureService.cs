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
    public class ProcedureService : IProcedureService
    {
        private readonly IProcedureRepository _repository;

        public ProcedureService(IProcedureRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProcedureId>> Create(Procedure entity, CancellationToken cancellationToken = default)
        {
            // TODO: принимать реквест
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<ProcedureId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<ProcedureId>> Delete(ProcedureId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<ProcedureId>(Errors.Errors.FAILURE_DELETE);

            return result.Value;
        }

        public async Task<Result<List<Procedure>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<Procedure>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<Procedure>> GetById(ProcedureId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<Procedure>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<ProcedureId>> Update(Procedure entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<ProcedureId>(Errors.Errors.FAILURE_UPDATE);

            return result.Value;
        }
    }
}
