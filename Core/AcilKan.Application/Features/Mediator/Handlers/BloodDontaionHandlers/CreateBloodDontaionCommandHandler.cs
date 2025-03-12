using AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDontaionHandlers
{
    public class CreateBloodDontaionCommandHandler(IRepository<BloodDonation> _repository, IBloodDonationService _bloodDonationService,IBloodRequestService bloodRequestService, IDateTimeService _dateTimeService) : IRequestHandler<CreateBloodDontaionCommand>
    {


        public async Task Handle(CreateBloodDontaionCommand request, CancellationToken cancellationToken)
        {
            
            var userId = await _repository.GetCurrentUserIdAsync();
            // Kullanıcının kan grubu olup olmadığını kontrol et
            var userBloodGroup = await _bloodDonationService.GetUserBloodGroupAsync(userId);
            if (string.IsNullOrEmpty(userBloodGroup))
            {
                throw new Exception("Kan grubu bilgisi eksik! Kan bağışı yapabilmek için önce kan grubunuzu belirtmelisiniz.");
            }

            // Talep edilen kan bağışı isteğini getir
            var bloodRequest = await bloodRequestService.GetBloodRequestByIdAsync(request.BloodRequestId);
            if (bloodRequest == null)
            {
                throw new Exception("Kan bağışı isteği bulunamadı!");
            }

            // Bağışçının kan grubu ile talep edilen kan grubu uyuşuyor mu?
            if (bloodRequest.BloodGroup.ToString() != userBloodGroup)
            {
                throw new Exception($"Kan bağışı için uygun değilsiniz! Talep edilen kan grubu: {bloodRequest.BloodGroup}, sizin kan grubunuz: {userBloodGroup}.");
            }

            // Son 90 gün içinde bağış yapmış mı?
            var lastDonationDate = await _bloodDonationService.GetLastDonationDateAsync(userId);
            if (lastDonationDate.HasValue && (DateTime.UtcNow - lastDonationDate.Value).TotalDays < 90)
            {
                int remainingDays = 90 - (int)(DateTime.UtcNow - lastDonationDate.Value).TotalDays;
                throw new Exception($"Kan bağışı için uygun değilsiniz! {remainingDays} gün daha beklemelisiniz.");
            }

            // Türkiye saat dilimini merkezi servis üzerinden al
            DateTime currentDateTimeInTurkey = _dateTimeService.GetCurrentTimeInTurkey();

            var bloodDonation = new BloodDonation
            {
                BloodRequestId = request.BloodRequestId,
                DonorId = userId,
                UnitsDonated = 1, // Varsayılan olarak 1 ünite bağışlandı olarak ayarlanıyor
                RequestedDonationDate = currentDateTimeInTurkey,
                ArrivalDate = null, // Bağışçının henüz bağış noktasına ulaşmadığını varsayıyoruz
                DonationCompletionDate = null, // Bağış henüz tamamlanmadı
                ApprovalDate = null, // Onay süreci daha başlamadı
                LastUpdatedDate = currentDateTimeInTurkey, // İlk oluşturulma tarihi olarak ayarlanabilir
                Status = BloodDonationStatus.Requested, // İlk başta bağış talebi oluşturuldu
                RejectedReason = null, // Henüz bağış başarısız olmadı
                Notes = null, // Kullanıcıya veya bağış sürecine özel not henüz yok
                IsActive = true, // Yeni bağış oluşturulduğunda aktif olarak işaretleniyor
            };

            await _repository.CreateAsync(bloodDonation);   
        }
    }
}
