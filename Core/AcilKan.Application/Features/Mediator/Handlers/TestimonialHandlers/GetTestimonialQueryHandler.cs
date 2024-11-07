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
    public class GetTestimonialQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetTestimonialQueryResult
            {
                Id = x.Id,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                Name = x.Name,
            }).ToList();
        }
    }
}
