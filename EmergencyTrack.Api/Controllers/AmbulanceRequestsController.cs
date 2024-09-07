using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Infrastructure.Mssql;
using EmergencyTrack.Domain.Shared.Ids;

namespace EmergencyTrack.Api.Controllers
{
    public class AmbulanceRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmbulanceRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AmbulanceRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AmbulanceRequests.Include(a => a.EmergencyStation).Include(a => a.SickPerson);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AmbulanceRequests/Details/5
        public async Task<IActionResult> Details(AmbulanceRequestId id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulanceRequest = await _context.AmbulanceRequests
                .Include(a => a.EmergencyStation)
                .Include(a => a.SickPerson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ambulanceRequest == null)
            {
                return NotFound();
            }

            return View(ambulanceRequest);
        }

        // GET: AmbulanceRequests/Create
        public IActionResult Create()
        {
            ViewData["EmergencyStationId"] = new SelectList(_context.EmergencyStations, "Id", "Id");
            ViewData["SickPersonId"] = new SelectList(_context.SickPeople, "Id", "Id");
            return View();
        }

        // POST: AmbulanceRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SickPersonId,EmergencyStationId,Id")] AmbulanceRequest ambulanceRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ambulanceRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmergencyStationId"] = new SelectList(_context.EmergencyStations, "Id", "Id", ambulanceRequest.EmergencyStationId);
            ViewData["SickPersonId"] = new SelectList(_context.SickPeople, "Id", "Id", ambulanceRequest.SickPersonId);
            return View(ambulanceRequest);
        }

        // GET: AmbulanceRequests/Edit/5
        public async Task<IActionResult> Edit(AmbulanceRequestId id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulanceRequest = await _context.AmbulanceRequests.FindAsync(id);
            if (ambulanceRequest == null)
            {
                return NotFound();
            }
            ViewData["EmergencyStationId"] = new SelectList(_context.EmergencyStations, "Id", "Id", ambulanceRequest.EmergencyStationId);
            ViewData["SickPersonId"] = new SelectList(_context.SickPeople, "Id", "Id", ambulanceRequest.SickPersonId);
            return View(ambulanceRequest);
        }

        // POST: AmbulanceRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AmbulanceRequestId id, [Bind("SickPersonId,EmergencyStationId,Id")] AmbulanceRequest ambulanceRequest)
        {
            if (id != ambulanceRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ambulanceRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmbulanceRequestExists(ambulanceRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmergencyStationId"] = new SelectList(_context.EmergencyStations, "Id", "Id", ambulanceRequest.EmergencyStationId);
            ViewData["SickPersonId"] = new SelectList(_context.SickPeople, "Id", "Id", ambulanceRequest.SickPersonId);
            return View(ambulanceRequest);
        }

        // GET: AmbulanceRequests/Delete/5
        public async Task<IActionResult> Delete(AmbulanceRequestId id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulanceRequest = await _context.AmbulanceRequests
                .Include(a => a.EmergencyStation)
                .Include(a => a.SickPerson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ambulanceRequest == null)
            {
                return NotFound();
            }

            return View(ambulanceRequest);
        }

        // POST: AmbulanceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(AmbulanceRequestId id)
        {
            var ambulanceRequest = await _context.AmbulanceRequests.FindAsync(id);
            if (ambulanceRequest != null)
            {
                _context.AmbulanceRequests.Remove(ambulanceRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmbulanceRequestExists(AmbulanceRequestId id)
        {
            return _context.AmbulanceRequests.Any(e => e.Id == id);
        }
    }
}
