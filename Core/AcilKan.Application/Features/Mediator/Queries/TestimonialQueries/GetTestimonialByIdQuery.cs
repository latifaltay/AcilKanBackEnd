using AcilKan.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery(int id) : IRequest<GetTestimonialByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
