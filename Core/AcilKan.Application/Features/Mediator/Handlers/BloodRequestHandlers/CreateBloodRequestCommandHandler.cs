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
    public class CreateBloodRequestCommandHandler(IRepository<BloodRequest> _repository) : IRequestHandler<CreateBloodRequestCommand>
    {
        public async Task Handle(CreateBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            // Kan grubu seçimini enum olarak al
            var bloodGroupEnum = (BloodGroupType)request.BloodGroupId;

            // Türkiye saat dilimini kullan
            TimeZoneInfo turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTime currentDateTimeInTurkey = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, turkeyTimeZone);

            var value = new BloodRequest
            {
                RequesterId = userId,
                HospitalId = request.HospitalId,
                BloodGroup = bloodGroupEnum,
                PatientName = request.PatientName,
                PatientSurname = request.PatientSurname,
                RequestDate = currentDateTimeInTurkey, // Türkiye saati ile tarih
                IsActive = true,
                Status = "Beklemede"
            };
            await _repository.CreateAsync(value);
        }
    }
}
