using CSharpFunctionalExtensions;
using EmergencyTrack.Application.Repositories;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Infrastructure.Mssql.Repositories
{
    public class AmbulanceRequestRepository : IAmbulanceRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public AmbulanceRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Result<AmbulanceRequestId>> Create(AmbulanceRequest entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return Result.Failure<AmbulanceRequestId>("entity is null");

            await _context.AmbulanceRequests.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<Result<AmbulanceRequestId>> Delete(AmbulanceRequestId id, CancellationToken cancellationToken = default)
        {
            await _context.AmbulanceRequests
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task<Result<List<AmbulanceRequest>>> Get(CancellationToken cancellationToken = default)
        {
            return await _context.AmbulanceRequests
                .AsNoTracking()
                .Include(a => a.EmergencyStation)
                    .ThenInclude(e => e.District)
                        .ThenInclude(e => e.City)
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<AmbulanceRequest>> GetById(AmbulanceRequestId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AmbulanceRequests
                .Include(a => a.CauseOfRecalls)
                .Include(a => a.EmergencyStation)
                    .ThenInclude(e => e.District)
                        .ThenInclude(e => e.City)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (entity == null)
                return Result.Failure<AmbulanceRequest>("Entity not found");

            return entity;
        }

        public async Task<Result<AmbulanceRequestId>> Update(AmbulanceRequest entity, CancellationToken cancellationToken = default)
        {
            _context.AmbulanceRequests.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
