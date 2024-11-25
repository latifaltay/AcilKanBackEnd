using AcilKan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface IBloodDonationApproveService
    {
        Task<List<BloodDonationApprove>> GetBloodDonationApprovesByDonorIdAsync(int DonorId);
        Task<List<BloodDonationApprove>> GetBloodDonationApprovesByRequesterIdAsync(int RequesterId);
    }
}
