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
    public class GetContactInformationByIdQueryHandler(IRepository<ContactInformation> _repository) : IRequestHandler<GetContactInformationByIdQuery, GetContactInformationByIdQueryResult>
    {
        public async Task<GetContactInformationByIdQueryResult> Handle(GetContactInformationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetContactInformationByIdQueryResult 
            {
                Id = value.Id,
                Title = value.Title,
                Address = value.Address,
                Mail = value.Mail,
                Phone = value.Phone,
            };
        }
    }
}
