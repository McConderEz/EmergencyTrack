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
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly ApplicationDbContext _context;

        public ProcedureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<ProcedureId>> Create(Procedure entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<ProcedureId>("entity is null");

            await _context.Procedures.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<ProcedureId>> Delete(ProcedureId id, CancellationToken cancellationToken = default)
        {
            await _context.Procedures
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<Procedure>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.Procedures
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<Procedure>> GetById(ProcedureId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Procedures
                .Include(p => p.ProcedurePerformeds)
                    .ThenInclude(p => p.AmbulanceRequest)
                        .ThenInclude(a => a.EmergencyStation)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<Procedure>("Entity not found");

            return entity;
        }

        public async Task<Result<ProcedureId>> Update(Procedure entity, CancellationToken cancellationToken = default)
        {
            _context.Procedures.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
