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
    public class GetContactUsQueryHandler(IRepository<ContactUs> _repository) : IRequestHandler<GetContactUsQuery, List<GetContactUsQueryResult>>
    {
        public async Task<List<GetContactUsQueryResult>> Handle(GetContactUsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetContactUsQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Subject = x.Subject,
                Message = x.Message,
                PhoneNumber = x.PhoneNumber,
                SendDate = x.SendDate,
                Email = x.Email,
            }).ToList();
        }
    }
}
