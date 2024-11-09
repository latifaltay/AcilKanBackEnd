using AcilKan.Application.Features.Mediator.Queries.ContactInformationQueries;
using AcilKan.Application.Features.Mediator.Results.ContactInformationResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.ContactInformationHandlers
{
    public class GetContactInformationQueryHandler(IRepository<ContactInformation> _repository) : IRequestHandler<GetContactInformationQuery, List<GetContactInformationQueryResult>>
    {
        public async Task<List<GetContactInformationQueryResult>> Handle(GetContactInformationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactInformationQueryResult 
            {
                Id = x.Id,
                Title = x.Title,
                Address = x.Address,    
                Mail = x.Mail,
                Phone = x.Phone,
            }).ToList();
        }
    }
}
