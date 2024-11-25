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
    public class AppUserRepository(AcilKanContext _context) : IAppUserService
    {
        public async Task<List<AppUser>> GetUsersWithDetailsAsync()
        {
            var values = await _context.Set<AppUser>()
                .Include(x => x.City)
                .ThenInclude(x => x.Districts).ToListAsync();
            return values;
        }

        public async Task<AppUser> GetUsersWithDetailsByIdAsync(int id)
        {
            var user = await _context.Set<AppUser>()
                .Include(x => x.City) 
                .ThenInclude(city => city.Districts) 
                .FirstOrDefaultAsync(x => x.Id == id); 

            return user;
        }
    }
}
