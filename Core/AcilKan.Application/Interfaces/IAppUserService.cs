using AcilKan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUser> GetUsersWithDetailsByIdAsync(int id);
        Task<List<AppUser>> GetUsersWithDetailsAsync();
    }
}
