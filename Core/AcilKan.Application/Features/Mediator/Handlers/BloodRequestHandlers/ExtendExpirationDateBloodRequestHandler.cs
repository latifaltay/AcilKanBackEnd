using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class ExtendExpirationDateBloodRequestHandler : IRequestHandler<ExtendExpirationDateBloodRequestCommand, string>
    {
        private readonly IRepository<BloodRequest> _repository;
        private readonly IDateTimeService _dateTimeService;
        private readonly IBloodRequestService _bloodRequestService;

        public ExtendExpirationDateBloodRequestHandler(IRepository<BloodRequest> repository, IDateTimeService dateTimeService, IBloodRequestService bloodRequestService )
        {
            _repository = repository;
            _dateTimeService = dateTimeService;
            _bloodRequestService = bloodRequestService;
        }

        public async Task<string> Handle(ExtendExpirationDateBloodRequestCommand request, CancellationToken cancellationToken)
        {
    
            var userId = await _repository.GetCurrentUserIdAsync();

            var userRequestList = await _bloodRequestService.GetBloodRequestsByUserIdAsync(userId);
            var value = userRequestList.FirstOrDefault(x => x.Id == request.RequestId);

            if (value == null)
                throw new Exception("Talep bulunamadı.");

            if (value.RequesterId != userId)
                throw new Exception("Bu talebin süresini uzatma yetkiniz yok.");

            if (!value.IsActive)
                throw new Exception("Bu talep zaten iptal edilmiş veya aktif değil.");

            // `CompletedByDonor (5)` veya `ApprovedByAdmin (6)` durumundaki aktif bağışları hesapla
            var totalDonatedUnits = value.Donations
                .Where(d => (d.Status == BloodDonationStatus.CompletedByDonor || d.Status == BloodDonationStatus.ApprovedByRequester)
                            && d.IsActive)
                .Sum(d => d.UnitsDonated ?? 0);

            if (totalDonatedUnits >= value.RequiredUnits)
                throw new Exception("Bu talep, bağışlarla karşılandığı için tamamlanmıştır ve süresi uzatılamaz.");


            value.ExpiryDate = value.ExpiryDate.HasValue
                ? value.ExpiryDate.Value.AddDays(1)
                : _dateTimeService.GetCurrentTimeInTurkey().AddDays(1);

            value.LastUpdatedDate = _dateTimeService.GetCurrentTimeInTurkey();
            await _repository.UpdateAsync(value);

            return "Talebin süresi 1 gün uzatıldı.";
        }
    }

}
