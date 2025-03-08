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
        private readonly IDateTimeService _dateTimeService;

        public CreateBloodRequestCommandHandler(
            IRepository<BloodRequest> repository,
            IDateTimeService dateTimeService)
        {
            _repository = repository;
            _dateTimeService = dateTimeService;
        }

        public async Task Handle(CreateBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            // Kan grubu seçimini enum olarak al
            var bloodGroupEnum = (BloodGroupType)request.BloodGroupId;

            // Türkiye saat dilimini merkezi servis üzerinden al
            DateTime currentDateTimeInTurkey = _dateTimeService.GetCurrentTimeInTurkey();

            var value = new BloodRequest
            {
                RequesterId = userId,
                HospitalId = request.HospitalId,
                BloodGroup = bloodGroupEnum,
                PatientName = request.PatientName,
                PatientSurname = request.PatientSurname,
                RequestDate = _dateTimeService.GetCurrentTimeInTurkey(),
                ExpiryDate = _dateTimeService.GetCurrentTimeInTurkey().AddHours(24),
                IsActive = true,
                Status = BloodRequestStatus.Requested // Enum kullanımı
            };

            await _repository.CreateAsync(value);
        }
    }
}
