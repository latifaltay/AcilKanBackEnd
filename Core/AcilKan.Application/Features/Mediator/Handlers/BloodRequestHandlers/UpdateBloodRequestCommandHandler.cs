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
    public class UpdateBloodRequestCommandHandler(IRepository<BloodRequest> _repository) : IRequestHandler<UpdateBloodRequestCommand>
    {
        public async Task Handle(UpdateBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            value.BloodGroupId = request.BloodGroupId;
            value.HospitalId = request.HospitalId;
            value.PatientName = request.PatientName;
            value.PatientSurname = request.PatientSurname;

            await _repository.UpdateAsync(value);
        }
    }
}