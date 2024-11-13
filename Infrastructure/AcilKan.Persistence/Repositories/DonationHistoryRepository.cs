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
        public async Task<List<DonationHistory>> GetAllDonationHistoryByUserIdAsync(int id)
        {
            return await _context.DonationHistories
                .Where(x => x.UserId == id)
                //.Include(x => x.Hospital.Name) 
                .Include(x => x.Hospital)
                .Include(x => x.DonationStatus)
                .ToListAsync();
        }


        public async Task<(int TotalDonations, DateTime? LastDonationDate)> GetDonationInfoByUserIdAsync(int userId)
        {
            var result = await _context.DonationHistories
                .Where(x => x.UserId == userId && x.DonationStatusId == 2)
                .GroupBy(x => x.UserId)
                .Select(g => new
                {
                    TotalDonations = g.Count(),
                    LastDonationDate = g.Max(x => x.DonationDate)
                })
                .FirstOrDefaultAsync();

            return result != null ? (result.TotalDonations, result.LastDonationDate) : (0, null);
        }


    }
}
