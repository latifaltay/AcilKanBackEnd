using AcilKan.Application.Features.Mediator.Commands.MissionCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.MissionHandlers
{
    public class DeleteMissionCommandHandler(IRepository<Mission> _repository) : IRequestHandler<DeleteMissionCommand>
    {
        async Task IRequestHandler<DeleteMissionCommand>.Handle(DeleteMissionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
