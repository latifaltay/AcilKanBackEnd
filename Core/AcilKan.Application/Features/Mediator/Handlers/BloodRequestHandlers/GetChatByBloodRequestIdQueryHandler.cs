using AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries;
using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class GetChatByBloodRequestIdQueryHandler(IBloodRequestService _service) : IRequestHandler<GetChatByBloodRequestIdQuery, GetChatByBloodRequestIdQueryResult>
    {
        // özel metot Blood servisin içinden çıkartılacak
        public async Task<GetChatByBloodRequestIdQueryResult> Handle(GetChatByBloodRequestIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _service.GetRequesterUserIdByBloodRequestIdAsync(request.BloodRequestId);
            return new GetChatByBloodRequestIdQueryResult
            {
                //RequesterUserId = value.AppUser.Id,
                RequesterUserName = value.AppUser.Name + " " + value.AppUser.Surname,
            };       
        }
    }
}
