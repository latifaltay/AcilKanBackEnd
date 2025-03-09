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
    public class BloodDonationRepository(AcilKanContext _context) : IBloodDonationService
    {
        public async Task<List<BloodDonation>> GetBloodDonationsAsync()
        {
            var values = await _context.BloodDonations
                .Include(x => x.BloodRequest)
                    .ThenInclude(x => x.Hospital)
                .Include(x => x.Donor).ToListAsync();

            return values;
                
        }


        public async Task<List<BloodDonation>> GetBloodDonationsByDonorIdAsync(int DonorId)
        {
            var values = await _context.BloodDonations
                .Where(x => x.DonorId == DonorId)
                .Include(x => x.BloodRequest)
                    .ThenInclude(x => x.Hospital)
                .Include(x => x.Donor).ToListAsync();

            return values;
        }

        
        public async Task<int> GetCompletedDonationCountByUserIdAsync(int userId) 
        {
            var values = await _context.BloodDonations
                .Include(x => x.BloodRequest)
                .Where(x => x.DonorId == userId && x.Status==Domain.Enums.BloodDonationStatus.ApprovedByRequester)
                .CountAsync();

            return values;
        }


        public async Task<DateOnly?> GetLastCompletedDonationDateByUserIdAsync(int userId)
        {
            return await _context.BloodDonations
                .Where(x => x.DonorId == userId && x.DonationCompletionDate.HasValue)
                .OrderByDescending(x => x.DonationCompletionDate)
                .Select(x => x.DonationCompletionDate.HasValue
                    ? DateOnly.FromDateTime(x.DonationCompletionDate.Value)
                    : (DateOnly?)null)
                .FirstOrDefaultAsync();
        }



    }
}
