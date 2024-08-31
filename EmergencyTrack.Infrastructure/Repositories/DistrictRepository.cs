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
    public class DistrictRepository : IDistrictRepository
    {
        private readonly ApplicationDbContext _context;

        public DistrictRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<DistrictId>> Create(District entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<DistrictId>("entity is null");

            await _context.Districts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<DistrictId>> Delete(DistrictId id, CancellationToken cancellationToken = default)
        {
            await _context.Districts
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<District>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.Districts
                .AsNoTracking()
                .Include(d => d.City)
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<District>> GetById(DistrictId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Districts
                .Include(a => a.City)
                .Include(d => d.EmergencyStations)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<District>("Entity not found");

            return entity;
        }

        public async Task<Result<DistrictId>> Update(District entity, CancellationToken cancellationToken = default)
        {
            _context.Districts.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
