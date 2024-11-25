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
    public class BloodDonationApproveRepository(AcilKanContext _context, IRepository<BloodDonationApprove> _repository) : IBloodDonationApproveService
    {
        public async Task<List<BloodDonationApprove>> GetBloodDonationApprovesByDonorIdAsync(int DonorId)
        {
            var values = await _context.BloodDonationApproves
                .Where(x => x.DonorId == DonorId).ToListAsync();
            return values;
        }


        public async Task<List<BloodDonationApprove>> GetBloodDonationApprovesByRequesterIdAsync(int RequesterId)
        {
            var values = await _context.BloodDonationApproves
                .Where(x => x.DonorId == RequesterId).ToListAsync();
            return values;
        }
    }
}
