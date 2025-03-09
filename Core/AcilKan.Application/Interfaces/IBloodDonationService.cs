using AcilKan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface IBloodDonationService
    {
        Task<List<BloodDonation>> GetBloodDonationsAsync(); 
        Task<List<BloodDonation>> GetBloodDonationsByDonorIdAsync(int donorId);
        Task<int> GetCompletedDonationCountByUserIdAsync(int userId);
        Task<DateOnly?> GetLastCompletedDonationDateByUserIdAsync(int userId);

    }
}
