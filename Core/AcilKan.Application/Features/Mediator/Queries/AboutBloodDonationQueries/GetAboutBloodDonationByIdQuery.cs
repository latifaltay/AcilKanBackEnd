using AcilKan.Application.Features.Mediator.Results.AboutBloodDonationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.AboutBloodDonationQueries
{
    public class GetAboutBloodDonationByIdQuery(int id) : IRequest<GetAboutBloodDonationByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
