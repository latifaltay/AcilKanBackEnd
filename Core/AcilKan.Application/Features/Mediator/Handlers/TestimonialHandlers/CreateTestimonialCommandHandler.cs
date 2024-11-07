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
    public class CreateTestimonialCommandHandler(IRepository<Testimonial> _repository) : IRequestHandler<CreateTestimonialCommand>
    {
        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Testimonial
            {
                Comment = request.Comment,
                ImageUrl = request.ImageUrl,
                Title = request.Title,
                Name = request.Name,
            });
        }
    }
}
