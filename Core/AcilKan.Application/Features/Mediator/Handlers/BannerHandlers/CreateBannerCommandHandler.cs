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
    public class CreateBannerCommandHandler(IRepository<Banner> _repository) : IRequestHandler<CreateBannerCommand>
    {
        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Banner 
            {
                Title = request.Title,
                Description = request.Description,
                CoverImageUrl = request.CoverImageUrl,
            });
        }
    }
}
