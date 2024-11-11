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
    public class DistrictRepository(AcilKanContext _context) : IDistrictService
    {
        public async Task<List<Hospital>> GetAllHospitalsByDistrictIdAsync(int id)
        {
            return await _context.Hospitals.Where(x => x.DistrictId == id).ToListAsync();
        }
    }
}
