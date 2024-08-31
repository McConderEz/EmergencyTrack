using CSharpFunctionalExtensions;
using EmergencyTrack.Application.Repositories;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Infrastructure.Mssql.Repositories
{
    public class CauseOfRecallRepository : ICauseOfRecallRepository
    {
        private readonly ApplicationDbContext _context;

        public CauseOfRecallRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<CauseOfRecallId>> Create(CauseOfRecall entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<CauseOfRecallId>("entity is null");

            await _context.CauseOfRecalls.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<CauseOfRecallId>> Delete(CauseOfRecallId id, CancellationToken cancellationToken = default)
        {
            await _context.CauseOfRecalls
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<CauseOfRecall>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.CauseOfRecalls
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<CauseOfRecall>> GetById(CauseOfRecallId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.CauseOfRecalls
                .Include(a => a.AmbulanceRequest)
                    .ThenInclude(e => e.EmergencyStation)
                        .ThenInclude(e => e.District)
                            .ThenInclude(d => d.City)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<CauseOfRecall>("Entity not found");

            return entity;
        }

        public async Task<Result<CauseOfRecallId>> Update(CauseOfRecall entity, CancellationToken cancellationToken = default)
        {
            _context.CauseOfRecalls.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
