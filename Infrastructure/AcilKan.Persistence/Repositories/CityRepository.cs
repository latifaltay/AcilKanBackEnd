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
    public class CityRepository(AcilKanContext _context) : ICityService
    {
        public async Task<List<District>> GetAllDistrictsByCityIdAsync(int id)
        {
            return await _context.Districts.Where(x => x.CityId == id).ToListAsync();
        }

        public async Task<List<Hospital>> GetAllHospitalsByCityIdAsync(int id)
        {
            return await _context.Hospitals.Where(x => x.District.CityId == id).ToListAsync();
        }
    }
}
