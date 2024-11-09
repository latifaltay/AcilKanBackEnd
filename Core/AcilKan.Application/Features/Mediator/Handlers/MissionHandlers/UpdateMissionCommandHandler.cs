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
    public class UpdateMissionCommandHandler(IRepository<Mission> _repository) : IRequestHandler<UpdateMissionCommand>
    {
        public async Task Handle(UpdateMissionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            value.Title = request.Title;
            value.Description = request.Description;

            await _repository.UpdateAsync(value);
        }
    }
}
