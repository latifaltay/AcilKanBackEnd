using AcilKan.Application.Features.Mediator.Commands.TestimonialCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class DeleteTestimonialCommandHandler(IRepository<Testimonial> _repository) : IRequestHandler<DeleteTestimonialCommand>
    {
        async Task IRequestHandler<DeleteTestimonialCommand>.Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
