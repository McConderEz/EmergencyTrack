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
    public class ProcedurePerformedService : IProcedurePerformedService
    {
        private readonly IProcedurePerformedRepository _repository;

        public ProcedurePerformedService(IProcedurePerformedRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProcedurePerformedId>> Create(ProcedurePerformed entity, CancellationToken cancellationToken = default)
        {
            // TODO: принимать реквест
            var result = await _repository.Create(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<ProcedurePerformedId>(Errors.Errors.FAILURE_CREATION);

            return result.Value;
        }

        public async Task<Result<ProcedurePerformedId>> Delete(ProcedurePerformedId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<ProcedurePerformedId>(Errors.Errors.FAILURE_DELETE);

            return result.Value;
        }

        public async Task<Result<List<ProcedurePerformed>>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(cancellationToken);

            if (result.IsFailure)
                return Result.Failure<List<ProcedurePerformed>>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<ProcedurePerformed>> GetById(ProcedurePerformedId id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<ProcedurePerformed>(Errors.Errors.FAILURE_GET);

            return result.Value;
        }

        public async Task<Result<ProcedurePerformedId>> Update(ProcedurePerformed entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);

            if (result.IsFailure)
                return Result.Failure<ProcedurePerformedId>(Errors.Errors.FAILURE_UPDATE);

            return result.Value;
        }
    }
}
