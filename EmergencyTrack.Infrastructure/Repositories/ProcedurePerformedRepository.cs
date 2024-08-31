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
    public class ProcedurePerformedRepository : IProcedurePerformedRepository
    {

        private readonly ApplicationDbContext _context;

        public ProcedurePerformedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<ProcedurePerformedId>> Create(ProcedurePerformed entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<ProcedurePerformedId>("entity is null");

            await _context.ProcedurePerformeds.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<ProcedurePerformedId>> Delete(ProcedurePerformedId id, CancellationToken cancellationToken = default)
        {
            await _context.ProcedurePerformeds
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<ProcedurePerformed>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.ProcedurePerformeds
                .AsNoTracking()
                .Include(p => p.AmbulanceRequest)
                    .ThenInclude(a => a.EmergencyStation)
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<ProcedurePerformed>> GetById(ProcedurePerformedId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.ProcedurePerformeds
                .Include(p => p.AmbulanceRequest)
                    .ThenInclude(a => a.EmergencyStation)
                .Include(p => p.AmbulanceRequest)
                    .ThenInclude(a => a.CauseOfRecalls)
                .Include(p => p.AmbulanceRequest)
                    .ThenInclude(a => a.SickPerson)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<ProcedurePerformed>("Entity not found");

            return entity;
        }

        public async Task<Result<ProcedurePerformedId>> Update(ProcedurePerformed entity, CancellationToken cancellationToken = default)
        {
            _context.ProcedurePerformeds.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
