using AcilKan.Application.Extensions;
using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using AcilKan.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Persistence.Repositories
{
    public class BloodRequestRepository(AcilKanContext _context) : IBloodRequestService
    {
        public async Task<List<BloodRequest>> GetBloodRequestsAsync()
        {
            var bloodRequests = await _context.BloodRequests
      .Where(x => x.IsActive == true &&
                  x.RequiredUnits > 0 && // ihtiyaç olan kan ünite sayısı 0dan büyük olanlar
                  x.ExpiryDate > DateTime.UtcNow && // Süresi dolmamış olanlar
                  x.Status == BloodRequestStatus.Requested) // Statüsü "Requested" olanlar
      .Include(x => x.Hospital)
          .ThenInclude(x => x.District)
          .ThenInclude(x => x.City)
      .Include(x => x.AppUser)
      .Include(x => x.Donations) // Bağış yapanları da çekiyoruz
            .ThenInclude(d => d.Donor) // Donor bilgilerini de çekiyoruz
      .OrderByDescending(x => x.RequestDate)
      .ToListAsync();

            return bloodRequests;

        }
        public async Task<BloodRequest> GetBloodRequestByIdAsync(int requestId)
        {
            return await _context.BloodRequests
                .Where(x => x.Id == requestId && x.IsActive && x.Status != BloodRequestStatus.Completed && x.Status!=BloodRequestStatus.CanceledByAdmin && x.Status!=BloodRequestStatus.Expired)
                .FirstOrDefaultAsync() ?? throw new Exception("Kan bağışı isteği bulunamadı.");
        }
        public async Task<BloodRequest> GetBloodRequestWithDetailsByIdAsync(int id)
        {
            var bloodRequest = await _context.BloodRequests
                .Include(x => x.Hospital)
                    .ThenInclude(x => x.District)
                    .ThenInclude(x => x.City)
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync(x => x.Id == id);
            return bloodRequest;
        }

        public async Task<BloodRequest> GetRequesterUserIdByBloodRequestIdAsync(int id)
        {
            var value = await _context.BloodRequests
                .Where(x => x.Id == id)
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync();
            return value;
        }

        public async Task<bool> IsActiveAndBloodRequestStatusByTCAsync(string tc)
        {
            var exists = await _context.BloodRequests
                .AnyAsync(x => x.PatientTC == tc && x.Status == BloodRequestStatus.Requested && x.IsActive && x.ExpiryDate > DateTime.UtcNow);

            return !exists; // Eğer kayıt varsa false, yoksa true döndür
        }
        public async Task<List<BloodRequest>> GetBloodRequestsByUserIdAsync(int userId)
        {
            var bloodRequests = await _context.BloodRequests
                .Where(x => x.RequesterId == userId ) // Kullanıcının açtığı talepleri getir
                .Include(x => x.Hospital)
                    .ThenInclude(x => x.District)
                    .ThenInclude(x => x.City)
                .Include(x => x.AppUser)
                .Include(x => x.Donations)
                            .ThenInclude(d => d.Donor) // Donor bilgilerini de çekiyoruz
                .OrderByDescending(x => x.RequestDate)
                .ToListAsync();


      
            return bloodRequests.ToList();
        }
    }
}
