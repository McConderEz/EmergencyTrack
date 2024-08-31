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
    public class EmergencyStationRepository : IEmergencyStationRepository
    {
        private readonly ApplicationDbContext _context;

        public EmergencyStationRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Result<EmergencyStationId>> Create(EmergencyStation entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<EmergencyStationId>("entity is null");

            await _context.EmergencyStations.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<EmergencyStationId>> Delete(EmergencyStationId id, CancellationToken cancellationToken = default)
        {
            await _context.EmergencyStations
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<EmergencyStation>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.EmergencyStations
                .AsNoTracking()
                .Include(e => e.District)
                    .ThenInclude(d => d.City)
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<EmergencyStation>> GetById(EmergencyStationId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.EmergencyStations
                .Include(e => e.AmbulanceRequests)
                    .ThenInclude(a => a.CauseOfRecalls)
                .Include(e => e.AmbulanceRequests)
                    .ThenInclude(a => a.SickPerson)
                .Include(e => e.District)
                    .ThenInclude(d => d.City)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<EmergencyStation>("Entity not found");

            return entity;
        }

        public async Task<Result<EmergencyStationId>> Update(EmergencyStation entity, CancellationToken cancellationToken = default)
        {
            _context.EmergencyStations.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
