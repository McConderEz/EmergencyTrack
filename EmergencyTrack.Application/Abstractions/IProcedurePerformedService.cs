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
    public interface IProcedurePerformedService
    {
        Task<Result<ProcedurePerformedId>> Create(ProcedurePerformed entity, CancellationToken cancellationToken = default);
        Task<Result<ProcedurePerformedId>> Update(ProcedurePerformed entity, CancellationToken cancellationToken = default);
        Task<Result<ProcedurePerformedId>> Delete(ProcedurePerformedId id, CancellationToken cancellationToken = default);
        Task<Result<ProcedurePerformed>> GetById(ProcedurePerformedId id, CancellationToken cancellationToken = default);
        Task<Result<List<ProcedurePerformed>>> Get(CancellationToken cancellationToken = default);
    }
}
