using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using AcilKan.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AcilKan.Persistence.Repositories
{
    public class BloodDonationRepository(AcilKanContext _context, UserManager<AppUser> _userManager) : IBloodDonationService
    {

        public async Task<List<BloodDonation>> GetBloodDonationsAsync()
        {
            var values = await _context.BloodDonations
                .Include(x => x.BloodRequest)
                    .ThenInclude(x => x.Hospital)
                .Include(x => x.Donor).ToListAsync();

            return values;
                
        }

        public async Task<List<BloodDonation>> GetMyActiveBloodDonationsAsync(int userId)
        {
            return await _context.BloodDonations
                .Where(x => x.DonorId == userId && x.IsActive)
                .Include(x => x.BloodRequest) // Bağış isteğini dahil et
                    .ThenInclude(x => x.Hospital) // Hastane bilgisini ekle
                .Include(x => x.Donor) // Bağışçıyı dahil et
                .Include(x => x.BloodRequest.AppUser) // Bağış isteğini yapan kullanıcıyı dahil et
                .OrderByDescending(x => x.RequestedDonationDate)
                .ToListAsync();
        }
        public async Task<List<BloodDonation>> GetBloodDonationsByDonorIdAsync(int DonorId)
        {
            var values = await _context.BloodDonations
                .Where(x => x.DonorId == DonorId)
                .Include(x => x.BloodRequest)
                    .ThenInclude(x => x.Hospital)
                .Include(x => x.Donor).ToListAsync();

            return values;
        }

        
        public async Task<int> GetCompletedTotalDonationCountByUserIdAsync(int userId) 
        {
            var values = await _context.BloodDonations
                .Include(x => x.BloodRequest)
                .Where(x => x.DonorId == userId && x.Status== Domain.Enums.BloodDonationStatus.ApprovedByRequester)
                .CountAsync();

            return values;
        }


        public async Task<DateOnly?> GetCompletedLastDonationDateByUserIdAsync(int userId)
        {
            var values = await _context.BloodDonations
                .Where(x => x.DonorId == userId && x.Status== Domain.Enums.BloodDonationStatus.CompletedByDonor)
                .OrderByDescending(x => x.DonationCompletionDate)
                .Select(x => x.DonationCompletionDate.HasValue
                    ? DateOnly.FromDateTime(x.DonationCompletionDate.Value)
                    : (DateOnly?)null)
                .FirstOrDefaultAsync();

            return values;
        }

        public async Task<BloodDonation> GetBloodDonationWithRequestAsync(int bloodDonationId)
        {
            return await _context.BloodDonations
                .Where(d => d.Id == bloodDonationId)
                .Include(d => d.BloodRequest) // **Bağış isteğiyle birlikte getir**
                    .ThenInclude(br => br.AppUser) // **Requester'ı getir**
                .FirstOrDefaultAsync();
        }
        public async Task<List<BloodDonation>> GetMyBloodDonationsAsync(int userId)
        {
            return await _context.BloodDonations
                .Where(x => x.DonorId == userId && x.IsActive)
                .Include(x => x.BloodRequest)
                    .ThenInclude(x => x.Hospital)
                .Include(x => x.Donor)
                .Include(x => x.BloodRequest.AppUser)
                .OrderByDescending(x => x.RequestedDonationDate)
                .ToListAsync();
        }
        // 🩸 Kullanıcının kan grubunu Identity üzerinden al
        public async Task<string> GetUserBloodGroupAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            return user.BloodGroup.ToString(); // BloodGroup enum olarak saklanıyorsa string'e çeviriyoruz
        }
        public async Task<DateTime?> GetLastDonationDateAsync(int userId)
        {
            var donations = await _context.BloodDonations
                .Where(x => x.DonorId == userId &&
                            x.Status != BloodDonationStatus.Expired &&  // Kan bağışı süresi doldu
                            x.Status != BloodDonationStatus.CanceledByDonor &&  // Bağış yapmaktan vazgeçti
                            x.Status != BloodDonationStatus.UnableToDonateDueToHealth &&  // Sağlık sorunu nedeniyle bağış yapamadı
                            x.Status != BloodDonationStatus.RejectedByRequester)  // Donör bağış yapmadı
                .ToListAsync();

            if (!donations.Any())
            {
                return null; // Eğer hiç geçerli bağış yoksa null döndür
            }

            return donations
                .Select(d => new[]
                {
            d.RequestedDonationDate,
            d.ArrivalDate,
            d.DonationCompletionDate,
            d.ApprovalDate,
            d.LastUpdatedDate
                })
                .SelectMany(dates => dates) // Tüm tarihleri tek bir listeye yay
                .Where(date => date.HasValue) // Sadece geçerli (null olmayan) tarihleri al
                .Max(date => date.Value); // En büyük (en güncel) tarihi döndür
        }

        public async Task UpdateAsync(BloodDonation bloodDonation)
        {
            _context.BloodDonations.Update(bloodDonation);
            await _context.SaveChangesAsync();
        }
        public async Task<BloodDonation> GetByIdAsync(int id)
        {
            return await _context.BloodDonations
                .AsNoTracking()
                .Include(b => b.BloodRequest)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
