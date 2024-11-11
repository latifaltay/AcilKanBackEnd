using AcilKan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface ICityService
    {
        Task<List<District>> GetAllDistrictsByCityIdAsync(int id);
        Task<List<Hospital>> GetAllHospitalsByCityIdAsync(int id);
    }
}
