using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class CreateBloodRequestCommandHandler : IRequestHandler<CreateBloodRequestCommand>
    {
        private readonly IRepository<BloodRequest> _repository;
        private readonly IBloodRequestService _bloodRequestService;
        private readonly IDateTimeService _dateTimeService;
        private readonly ITCIdentityVerificationService _tcVerificationService;
        private readonly IRepository<Hospital> _hospitalRepository;
        public CreateBloodRequestCommandHandler(
            IRepository<BloodRequest> repository,
            IDateTimeService dateTimeService,
            ITCIdentityVerificationService tcVerificationService,IBloodRequestService bloodRequestService, IRepository<Hospital> hospitalRepository)
        {
            _repository = repository;
            _dateTimeService = dateTimeService;
            _tcVerificationService = tcVerificationService;
            _bloodRequestService = bloodRequestService;
            _hospitalRepository = hospitalRepository;
        }

        public async Task Handle(CreateBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            // TC Kimlik Numarası Doğrulaması
            bool isValidTC = await _tcVerificationService.ValidateTCIdentity(
                request.PatientTC, request.PatientName, request.PatientSurname, request.PatientBirtDate.Year
            );
            if (!isValidTC)
                throw new ArgumentException("Geçersiz Bilgilerle Kayıt Olmaya Çalışıyorsunuz! Lütfen doğru bilgileri giriniz.");

            // Aktif Kan Talebi Kontrolü (Aynı TC için aktif kayıt var mı?)
            bool isExistActiveAndBloodRequestStatusByTC = await _bloodRequestService.IsActiveAndBloodRequestStatusByTCAsync(request.PatientTC);
            if (!isExistActiveAndBloodRequestStatusByTC)
                throw new InvalidOperationException("Bu hastaya ait aktif bir kan talebi zaten mevcuttur.");

            // Hastane ID kontrolü
            var hospitalExists = await _hospitalRepository.GetByIdAsync(request.HospitalId);
            if (hospitalExists == null)
                throw new ArgumentException("Geçersiz Hastane ID. Lütfen sistemde kayıtlı bir hastane seçin.");

            // RequiredUnits (Gerekli Kan Ünite Sayısı) Validasyonu
            if (request.RequiredUnits <= 0)
                throw new ArgumentException("İhtiyaç duyulan ünite sayısı pozitif bir değer olmalıdır.");
            if (request.RequiredUnits > 10)
                throw new ArgumentException("Maksimum 10 ünite kan talep edebilirsiniz.");

            // Enum validasyonu: Kan Grubu
            if (!Enum.IsDefined(typeof(BloodGroupType), request.BloodGroupId))
                throw new ArgumentException("Geçersiz kan grubu seçildi. Lütfen geçerli bir kan grubu seçin.");

            // Enum validasyonu: Talep Sebebi
            if (!Enum.IsDefined(typeof(DemandReasonType), request.DemandReasonTypeId))
                throw new ArgumentException("Geçersiz talep sebebi seçildi. Lütfen geçerli bir sebep seçin.");

            // Türkiye saat dilimini merkezi servis üzerinden al
            DateTime currentDateTimeInTurkey = _dateTimeService.GetCurrentTimeInTurkey();

            var value = new BloodRequest
            {
                RequesterId = userId,
                HospitalId = request.HospitalId,
                IsIndependentDonation = request.IsIndependentDonation,
                BloodGroup = (BloodGroupType)request.BloodGroupId,
                RequiredUnits = request.RequiredUnits,
                PatientName = request.PatientName,
                PatientSurname = request.PatientSurname,
                PatientTC = request.PatientTC,
                PatientBirthDate = request.PatientBirtDate,
                PatientGender = request.PatientGender ?? null,
                DemandReason = (DemandReasonType)request.DemandReasonTypeId,
                IsActive = true,
                Status = BloodRequestStatus.Requested,
                RequestDate = currentDateTimeInTurkey,
                ExpiryDate = currentDateTimeInTurkey.AddHours(24),
                CompletionDate = null,
                LastUpdatedDate = null,
            };

            await _repository.CreateAsync(value);
        }
    }
}
