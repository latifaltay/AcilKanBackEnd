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
    public class CreateMissionCommandHandler(IRepository<Mission> _repository) : IRequestHandler<CreateMissionCommand>
    {
        public async Task Handle(CreateMissionCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Mission
            {
                Title = request.Title,
                Description = request.Description,
            });
        }
    }
}
