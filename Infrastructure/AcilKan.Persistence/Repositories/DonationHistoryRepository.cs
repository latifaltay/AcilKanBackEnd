using AcilKan.Application.Features.Mediator.Results.DonationHistoryResults;
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
    public class DonationHistoryRepository(AcilKanContext _context) : IDonationHistoryService
    {
        public async Task<List<BloodDontaion>> GetAllDonationHistoryByUserIdAsync(int id)
        {
            return await _context.DonationHistories
                .Where(x => x.DonorId == id)
                .Include(x => x.Hospital)
                .Include(x => x.DonationStatus)
                .ToListAsync();
        }


        public async Task<(int TotalDonations, DateTime? LastDonationDate)> GetDonationInfoByUserIdAsync(int userId)
        {
            var result = await _context.DonationHistories
                .Where(x => x.DonorId == userId && x.DonationStatusId == 2)
                .GroupBy(x => x.DonorId)
                .Select(g => new
                {
                    TotalDonations = g.Count(),
                    LastDonationDate = g.Max(x => x.DonationDate)
                })
                .FirstOrDefaultAsync();

            return result != null ? (result.TotalDonations, result.LastDonationDate) : (0, null);
        }

        public async Task<List<BloodDontaion>> GetRequestDonationsByUserIdAsync(int userId)
        {
            return await _context.DonationHistories
                .Where(x => x.DonorId == userId && x.DonationType == true)
                .Include(x => x.Hospital)
                .Include(x => x.DonationStatus)
                .ToListAsync();
        }

        public async Task<List<BloodDontaion>> GetSentDonationsByUserIdAsync(int userId)
        {
            return await _context.DonationHistories
                .Where(x => x.DonorId == userId && x.DonationType == false)
                .Include(x => x.Hospital)
                .Include(x => x.DonationStatus)
                .ToListAsync();
        }
    }
}
