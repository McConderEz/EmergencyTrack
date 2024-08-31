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
    public class SickPersonRepository : ISickPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public SickPersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<SickPersonId>> Create(SickPerson entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<SickPersonId>("entity is null");

            await _context.SickPeople.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<SickPersonId>> Delete(SickPersonId id, CancellationToken cancellationToken = default)
        {
            await _context.SickPeople
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<SickPerson>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.SickPeople
                .AsNoTracking()
                .Include(s => s.SocialStatus)
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<SickPerson>> GetById(SickPersonId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.SickPeople
                .Include(s => s.SocialStatus)
                .Include(s => s.AmbulanceRequests)
                    .ThenInclude(a => a.EmergencyStation)
                .Include(s => s.AmbulanceRequests)
                    .ThenInclude(a => a.CauseOfRecalls)
                .Include(s => s.AmbulanceRequests)
                    .ThenInclude(a => a.ProcedurePerformeds)
                        .ThenInclude(p => p.Procedures)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<SickPerson>("Entity not found");

            return entity;
        }

        public async Task<Result<SickPersonId>> Update(SickPerson entity, CancellationToken cancellationToken = default)
        {
            _context.SickPeople.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
