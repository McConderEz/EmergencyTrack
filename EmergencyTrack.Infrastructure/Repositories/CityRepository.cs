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
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<CityId>> Create(City entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<CityId>("entity is null");

            await _context.Cities.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<CityId>> Delete(CityId id, CancellationToken cancellationToken = default)
        {
            await _context.Cities
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<City>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.Cities
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<City>> GetById(CityId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Cities
                .Include(a => a.Districts)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<City>("Entity not found");

            return entity;
        }

        public async Task<Result<CityId>> Update(City entity, CancellationToken cancellationToken = default)
        {
            _context.Cities.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
