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
    public class GetContactQueryHandler(IRepository<ContactPage> _repository) : IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
    {
        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetContactQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Message = x.Message,
                PhoneNumber = x.PhoneNumber,
                SendDate = x.SendDate,
                Email = x.Email,
            }).ToList();
        }
    }
}
