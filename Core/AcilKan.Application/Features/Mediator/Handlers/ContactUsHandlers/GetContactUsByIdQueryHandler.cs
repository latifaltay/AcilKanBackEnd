
using AcilKan.Application.Features.Mediator.Queries.ContactUsQueries;
using AcilKan.Application.Features.Mediator.Results.ContactUsResults;
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
    public class GetContactUsByIdQueryHandler(IRepository<ContactUs> _repository) : IRequestHandler<GetContactUsByIdQuery, GetContactUsByIdQueryResult>
    {
        public async Task<GetContactUsByIdQueryResult> Handle(GetContactUsByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetContactUsByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
                Surname = value.Surname,
                PhoneNumber = value.PhoneNumber,
                Email = value.Email,
                Subject = value.Subject,
                Message = value.Message,
                SendDate = value.SendDate,
            };
        }
    }
}
