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
    public interface IProcedureService
    {
        Task<Result<ProcedureId>> Create(Procedure entity, CancellationToken cancellationToken = default);
        Task<Result<ProcedureId>> Update(Procedure entity, CancellationToken cancellationToken = default);
        Task<Result<ProcedureId>> Delete(ProcedureId id, CancellationToken cancellationToken = default);
        Task<Result<Procedure>> GetById(ProcedureId id, CancellationToken cancellationToken = default);
        Task<Result<List<Procedure>>> Get(CancellationToken cancellationToken = default);
    }
}
