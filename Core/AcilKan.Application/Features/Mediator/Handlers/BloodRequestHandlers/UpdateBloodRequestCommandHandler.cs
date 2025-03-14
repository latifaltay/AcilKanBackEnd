using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class UpdateBloodRequestCommandHandler(
        IRepository<BloodRequest> _repository,
        IRepository<Hospital> _hospitalRepository) : IRequestHandler<UpdateBloodRequestCommand>
    {
        public async Task Handle(UpdateBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new KeyNotFoundException("Kan talebi bulunamadı.");

            var userId = await _repository.GetCurrentUserIdAsync();
            if (value.RequesterId != userId)
                throw new UnauthorizedAccessException("Sadece kendi oluşturduğunuz talepleri güncelleyebilirsiniz.");

            // İhtiyaç sayısı validasyonu
            if (request.RequiredUnits <= 0)
                throw new ArgumentException("İhtiyaç duyulan ünite sayısı pozitif bir değer olmalıdır.");
            if (request.RequiredUnits < value.RequiredUnits)
                throw new ArgumentException("İhtiyaç duyulan ünite sayısı azaltılamaz, sadece artırılabilir.");

            // Enum validasyonu (Geçerli olup olmadığı kontrol ediliyor)
            if (request.DemandReason.HasValue && !Enum.IsDefined(typeof(DemandReasonType), request.DemandReason.Value))
                throw new ArgumentException("Geçersiz talep sebebi. Lütfen geçerli bir sebep seçin.");

            // Hastane ID kontrolü (Geçerli olup olmadığı kontrol ediliyor)
            var hospital = await _hospitalRepository.GetByIdAsync(request.HospitalId);
            if (hospital == null)
                throw new ArgumentException("Geçersiz Hastane ID. Lütfen sistemde kayıtlı bir hastane seçin.");



            // Güncellenebilen alanlar
            value.IsIndependentDonation = request.IsIndependentDonation;
            value.HospitalId = request.HospitalId;
            value.RequiredUnits = request.RequiredUnits;
            value.PatientGender = request.PatientGender;
            value.DemandReason = request.DemandReason;
            value.LastUpdatedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(value);
        }
    }
}
