using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Persistence.Repositories
{
    public class BloodRequestRepository(AcilKanContext _context) : IBloodRequestService
    {
        public async Task<List<BloodRequest>> GetBloodRequestsAsync()
        {
            var bloodRequest = await _context.BloodRequests
                .Where(x => x.IsActive == true)
                .Include(x => x.Hospital)
                    .ThenInclude(x => x.District)
                    .ThenInclude(x => x.City)
                .Include(x => x.AppUser)
                .OrderByDescending(x => x.RequestDate)
                .ToListAsync();
            return bloodRequest;
        }

        public async Task<BloodRequest> GetBloodRequestWithDetailsByIdAsync(int id)
        {
            var bloodRequest = await _context.BloodRequests
                .Include(x => x.Hospital)
                    .ThenInclude(x => x.District)
                    .ThenInclude(x => x.City)
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync(x => x.Id == id);
            return bloodRequest;
        }

        public async Task<BloodRequest> GetRequesterUserIdByBloodRequestIdAsync(int id)
        {
            var value = await _context.BloodRequests
                .Where(x => x.Id == id)
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync();
            return value;
        }
    }
}
