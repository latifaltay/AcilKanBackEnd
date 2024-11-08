using AcilKan.Application.Features.Mediator.Queries.ContactQueries;
using AcilKan.Application.Features.Mediator.Results.ContactResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler(IRepository<ContactPage> _repository) : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetContactByIdQueryResult
            {
                Id = value.Id,
                Email = value.Email,
                SendDate = value.SendDate,
                PhoneNumber = value.PhoneNumber,
                Message = value.Message,
                Name = value.Name,
            };
        }
    }
}
