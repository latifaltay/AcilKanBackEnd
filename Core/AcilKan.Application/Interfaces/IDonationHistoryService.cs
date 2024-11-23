using AcilKan.Application.Features.Mediator.Results.DonationHistoryResults;
using AcilKan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface IDonationHistoryService
    {
        Task<List<BloodDontaion>> GetAllDonationHistoryByUserIdAsync(int id);
        Task<List<BloodDontaion>> GetSentDonationsByUserIdAsync(int userId);
        Task<List<BloodDontaion>> GetRequestDonationsByUserIdAsync(int userId);
        Task<(int TotalDonations, DateTime? LastDonationDate)> GetDonationInfoByUserIdAsync(int userId);
    }
}
