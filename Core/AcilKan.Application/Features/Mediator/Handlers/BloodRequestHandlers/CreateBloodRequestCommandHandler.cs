using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class CreateBloodRequestCommandHandler(IRepository<BloodRequest> _repository) : IRequestHandler<CreateBloodRequestCommand>
    {
        public async Task Handle(CreateBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            var value = new BloodRequest 
            {
                AppUserId = userId,
                HospitalId = request.HospitalId,
                BloodGroupId = request.BloodGroupId,
                PatientName = request.PatientName,
                PatientSurname = request.PatientSurname,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
            };
            await _repository.CreateAsync(value);
        }
    }
}
