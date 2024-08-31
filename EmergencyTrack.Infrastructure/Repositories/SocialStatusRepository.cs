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
    public class SocialStatusRepository: ISocialStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public SocialStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<SocialStatusId>> Create(SocialStatus entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<SocialStatusId>("entity is null");

            await _context.SocialStatuses.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<SocialStatusId>> Delete(SocialStatusId id, CancellationToken cancellationToken = default)
        {
            await _context.SocialStatuses
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<SocialStatus>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.SocialStatuses
                .AsNoTracking()
                .Include(s => s.SickPersons)
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<SocialStatus>> GetById(SocialStatusId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.SocialStatuses
               .Include(s => s.SickPersons)
               .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<SocialStatus>("Entity not found");

            return entity;
        }

        public async Task<Result<SocialStatusId>> Update(SocialStatus entity, CancellationToken cancellationToken = default)
        {
            _context.SocialStatuses.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
