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
    public class CancelBloodRequestCommandHandler(IRepository<BloodRequest> _repository) : IRequestHandler<CancelBloodRequestCommand>
    {
        public async Task Handle(CancelBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            value.IsActive = false;

            await _repository.UpdateAsync(value);
        }
    }
}
