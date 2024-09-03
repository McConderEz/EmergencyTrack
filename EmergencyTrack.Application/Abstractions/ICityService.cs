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
    public interface ICityService
    {
        Task<Result<CityId>> Create(City entity, CancellationToken cancellationToken = default);
        Task<Result<CityId>> Update(City entity, CancellationToken cancellationToken = default);
        Task<Result<CityId>> Delete(CityId id, CancellationToken cancellationToken = default);
        Task<Result<City>> GetById(CityId id, CancellationToken cancellationToken = default);
        Task<Result<List<City>>> Get(CancellationToken cancellationToken = default);
    }
}
