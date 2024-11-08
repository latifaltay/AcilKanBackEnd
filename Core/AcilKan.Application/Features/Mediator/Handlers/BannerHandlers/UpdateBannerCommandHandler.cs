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
    public class UpdateBannerCommandHandler(IRepository<Banner> _repository) : IRequestHandler<UpdateBannerCommand>
    {
        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Title = request.Title;
            value.Description = request.Description;
            value.CoverImageUrl = request.CoverImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
