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
    public class GetChatsToUserIdQueryHandler(IRepository<Chat> _repository, IChatService _service) : IRequestHandler<GetChatsToUserIdQuery, GetChatsToUserIdQueryResult>
    {
        public async Task<GetChatsToUserIdQueryResult> Handle(GetChatsToUserIdQuery request, CancellationToken cancellationToken)
        {
            var fromUserId = await _repository.GetCurrentUserIdAsync();
            var messages = await _service.GetChatsByUserOrderedByDateAsync(fromUserId, request.ToUserId);
            var firtMessage = messages.FirstOrDefault();

            string toUserFullName = string.Empty;

            if (firtMessage != null)
            {
                toUserFullName = firtMessage.ToUser.Name + ' ' + firtMessage.ToUser.Surname;
            }

            // Sonucu oluştur
            var result = new GetChatsToUserIdQueryResult
            {
                ToUserFullName = toUserFullName,
                MessageInfo = messages.Select(message => new MessageInfo
                {
                    Content = message.Message,
                    SendDate = message.SendDate
                }).ToList()
            };

            return result;

        }
    }
}
