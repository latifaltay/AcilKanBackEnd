using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums; // ✅ Enum'un olduğu namespace eklenmeli
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class CancelBloodRequestCommandHandler(IRepository<BloodRequest> _repository,IBloodRequestService _bloodRequestService, IDateTimeService _dateTimeService)
        : IRequestHandler<CancelBloodRequestCommand>
    {
        public async Task Handle(CancelBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            var userRequestList = await _bloodRequestService.GetBloodRequestsByUserIdAsync(userId);
            var value = userRequestList.FirstOrDefault(x => x.Id == request.Id);

            if (value == null)
                throw new Exception("Talep bulunamadı.");

            if (value.RequesterId != userId)
                throw new Exception("Bu talebi iptal etme yetkiniz yok.");

            if (!value.IsActive)
                throw new Exception("Bu talep zaten iptal edilmiş veya aktif değil.");

            // `CompletedByDonor (5)` veya `ApprovedByAdmin (6)` durumundaki aktif bağışları hesapla
            var totalDonatedUnits = value.Donations
                .Where(d => (d.Status == BloodDonationStatus.CompletedByDonor || d.Status == BloodDonationStatus.ApprovedByRequester)
                            && d.IsActive)
                .Sum(d => d.UnitsDonated ?? 0);

            if (totalDonatedUnits >= value.RequiredUnits)
                throw new Exception("Bu talep, bağışlarla karşılandığı için iptal edilemez.");

            DateTime currentDateTimeInTurkey = _dateTimeService.GetCurrentTimeInTurkey();

            // Tüm şartlar sağlandıysa iptal işlemini gerçekleştir
            value.IsActive = false;
            value.LastUpdatedDate = currentDateTimeInTurkey;
            await _repository.UpdateAsync(value);
        }

    }
}
