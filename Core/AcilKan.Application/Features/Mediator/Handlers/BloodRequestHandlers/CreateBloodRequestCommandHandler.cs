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
        public CreateBloodRequestCommandHandler(
            IRepository<BloodRequest> repository,
            IDateTimeService dateTimeService,
            ITCIdentityVerificationService tcVerificationService,IBloodRequestService bloodRequestService)
        {
            _repository = repository;
            _dateTimeService = dateTimeService;
            _tcVerificationService = tcVerificationService;
            _bloodRequestService = bloodRequestService;
        }

        public async Task Handle(CreateBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            bool isValidTC = await _tcVerificationService.ValidateTCIdentity(
             request.PatientTC, request.PatientName, request.PatientSurname, request.PatientBirtDate.Year
         );

            if (!isValidTC)
            {
                throw new Exception("Geçersiz TC Kimlik Numarası! Lütfen doğru bilgileri giriniz.");
            }




            bool isExistActiveAndBloodRequestStatusByTC = await _bloodRequestService.IsActiveAndBloodRequestStatusByTCAsync(request.PatientTC);

            if (!isExistActiveAndBloodRequestStatusByTC)
            {
                throw new Exception("Bu Hastaya Ait Aktif Kayıt Mevcuttur.");
            }

            // Kan grubu seçimini enum olarak al
            var bloodGroupEnum = (BloodGroupType)request.BloodGroupId;
            // Kan Talebi Sebebi seçimini enum olarak al
            var demandReasonEnum = (DemandReasonType)request.DemandReasonTypeId;

            // Türkiye saat dilimini merkezi servis üzerinden al
            DateTime currentDateTimeInTurkey = _dateTimeService.GetCurrentTimeInTurkey();

            var value = new BloodRequest
            {
                RequesterId = userId,
                HospitalId = request.HospitalId,
                IsIndependentDonation = request.IsIndependentDonation,
                BloodGroup = bloodGroupEnum,
                RequiredUnits = request.RequiredUnits,
                PatientName = request.PatientName,
                PatientSurname = request.PatientSurname,
                PatientTC = request.PatientTC,
                PatientBirthDate = request.PatientBirtDate,
                PatientGender = request.PatientGender ?? null,
                DemandReason = demandReasonEnum,
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
