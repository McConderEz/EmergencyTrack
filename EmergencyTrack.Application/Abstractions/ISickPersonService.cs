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
    public interface ISickPersonService
    {
        Task<Result<SickPersonId>> Create(SickPerson entity, CancellationToken cancellationToken = default);
        Task<Result<SickPersonId>> Update(SickPerson entity, CancellationToken cancellationToken = default);
        Task<Result<SickPersonId>> Delete(SickPersonId id, CancellationToken cancellationToken = default);
        Task<Result<SickPerson>> GetById(SickPersonId id, CancellationToken cancellationToken = default);
        Task<Result<List<SickPerson>>> Get(CancellationToken cancellationToken = default);
    }
}
