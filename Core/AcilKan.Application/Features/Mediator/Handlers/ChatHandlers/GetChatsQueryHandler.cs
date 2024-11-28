using AcilKan.Application.Features.Mediator.Queries.ChatQueries;
using AcilKan.Application.Features.Mediator.Results.ChatResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.ChatHandlers
{
    public class GetChatsQueryHandler(IChatService _service, IRepository<Chat> _repository) : IRequestHandler<GetChatsQuery, List<GetChatQueryResult>>
    {
        public async Task<List<GetChatQueryResult>> Handle(GetChatsQuery request, CancellationToken cancellationToken)
        {
            var UserId = await _repository.GetCurrentUserIdAsync();
            var chats = await _service.GetChatsByUserOrderedByDateAsync(UserId, request.ToUserId);
            return chats.Select(x => new GetChatQueryResult 
            {
                Id = x.UserId,
                ToUserId = x.ToUserId,
                UserId = x.ToUserId,
                Message = x.Message,
                SendDate = x.SendDate,
            }).ToList();

        }
    }
}
