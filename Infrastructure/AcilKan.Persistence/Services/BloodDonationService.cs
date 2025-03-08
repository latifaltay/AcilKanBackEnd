using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;

namespace AcilKan.Persistence.Services
{
    public class BloodDonationService(IRepository<BloodDonation> _repository) : IBloodDonationService
    {
        public async Task<List<BloodDonation>> GetBloodDonationsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<BloodDonation>> GetBloodDonationsByDonorIdAsync(int donorId)
        {
            var donations = await _repository.GetAllAsync();
            return donations.Where(d => d.DonorId == donorId).ToList();
        }

    }
}
