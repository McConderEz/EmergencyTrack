using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Common
{
    public interface ICrudRepository<T,TId>
        where T:notnull
    {
        Task<Result<TId>> Create(T entity, CancellationToken cancellationToken = default);
        Task<Result<TId>> Update(T entity, CancellationToken cancellationToken = default);
        Task<Result<TId>> Delete(TId id, CancellationToken cancellationToken = default);
        Task<Result<T>> GetById(TId id, CancellationToken cancellationToken = default);
        Task<Result<List<T>>> Get(CancellationToken cancellationToken = default);
    }
}
