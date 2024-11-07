using AcilKan.Application.Features.Mediator.Commands.BannerCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class DeleteBannerCommandHandler(IRepository<Banner> _repository) : IRequestHandler<DeleteBannerCommand>
    {
        public async Task Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
