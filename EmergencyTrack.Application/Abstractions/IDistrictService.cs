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
    public interface IDistrictService
    {
        Task<Result<DistrictId>> Create(District entity, CancellationToken cancellationToken = default);
        Task<Result<DistrictId>> Update(District entity, CancellationToken cancellationToken = default);
        Task<Result<DistrictId>> Delete(DistrictId id, CancellationToken cancellationToken = default);
        Task<Result<District>> GetById(DistrictId id, CancellationToken cancellationToken = default);
        Task<Result<List<District>>> Get(CancellationToken cancellationToken = default);
    }
}
