using AcilKan.Application.Features.Mediator.Queries.TestimonialQueries;
using AcilKan.Application.Features.Mediator.Results.TestimonialResults;
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
    public class GetTestimonialByIdQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
                Title = value.Title,
                ImageUrl = value.ImageUrl,
                Comment = value.Comment,
            };
        }
    }
}
