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
    public class UserProfileRepository(AcilKanContext _context) : IUserProfileService
    {
        public async Task<int> GetTotalDonationCountAsync(int userId)
        {
            var value = await _context.BloodDonationApproves
                .Where(x => x.DonorId == userId)
                .CountAsync();
            return value;
        }

        public async Task<AppUser> GetUserProfileWithDetailAsync(int userId)
        {
            var value = await _context.Users
                .Where(x => x.Id == userId)
                .Include(x => x.City)
                .Include(x => x.District)
                .Include(x => x.BloodDonationApproves)
                .FirstOrDefaultAsync();
            return value;
        }
    }
}
