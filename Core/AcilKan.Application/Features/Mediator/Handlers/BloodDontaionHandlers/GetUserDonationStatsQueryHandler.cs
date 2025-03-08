using AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries;
using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDontaionHandlers
{
    public class GetUserDonationStatsQueryHandler : IRequestHandler<GetUserDonationStatsQuery, GetUserDonationStatsQueryResult>
    {
        private readonly IRepository<BloodDonation> _repository;

        public GetUserDonationStatsQueryHandler(IRepository<BloodDonation> repository)
        {
            _repository = repository;
        }

        public Task<GetUserDonationStatsQueryResult> Handle(GetUserDonationStatsQuery request, CancellationToken cancellationToken)
        {
            var donations = _repository.GetAllAsync(d => d.DonorId == request.UserId).Result; // ✅ `async` kaldırıldı.

            // Toplam Bağış Sayısı
            int totalDonations = donations.Count();

            // En son yapılan bağışı bul
            var lastDonation = donations.OrderByDescending(d => d.DonationCompletionDate)
                                        .FirstOrDefault()?.DonationCompletionDate;

            string lastDonationAgo = lastDonation.HasValue
                ? GetTimeAgo(lastDonation.Value)
                : "Henüz bağış yapılmadı";

            // Yeni bağış yapabileceği tarihi hesapla (örneğin 90 gün sonra tekrar bağış yapabilir)
            DateTime? nextDonationDate = lastDonation?.AddDays(90);
            string nextDonationIn = nextDonationDate.HasValue
                ? GetTimeUntil(nextDonationDate.Value)
                : "Herhangi bir kayıt yok";

            return Task.FromResult(new GetUserDonationStatsQueryResult
            {
                TotalDonations = totalDonations,
                LastDonationAgo = lastDonationAgo,
                NextDonationIn = nextDonationIn
            });
        }

        // Son bağışın üzerinden geçen süreyi hesaplayan yardımcı metod
        private static string GetTimeAgo(DateTime lastDate)
        {
            var difference = DateTime.UtcNow - lastDate;
            if (difference.TotalDays >= 30)
                return $"{(int)(difference.TotalDays / 30)} ay önce";
            else if (difference.TotalDays >= 1)
                return $"{(int)difference.TotalDays} gün önce";
            else if (difference.TotalHours >= 1)
                return $"{(int)difference.TotalHours} saat önce";
            else
                return "Az önce";
        }

        // Yeni bağış yapabileceği süreyi hesaplayan yardımcı metod
        private static string GetTimeUntil(DateTime nextDate)
        {
            var difference = nextDate - DateTime.UtcNow;
            if (difference.TotalDays > 0)
                return $"{(int)difference.TotalDays} gün sonra";
            else
                return "Bağış yapabilirsiniz";
        }
    }
}
