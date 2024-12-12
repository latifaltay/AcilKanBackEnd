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
    public class GetContactsQueryHandler(IChatService _service, IRepository<Chat> _repository) : IRequestHandler<GetContactsQuery, List<GetContactsQueryResult>>
    {
        // kontrol et düzenlenecek
        public async Task<List<GetContactsQueryResult>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var UserId = await _repository.GetCurrentUserIdAsync();
            //var chats = await _service.GetChatsByUserOrderedByDateAsync(UserId, request.ToUserId);

            //var values = await _repository.GetAllAsync();
            //return values.Select(x => new GetContactsQueryResult
            //{
            //    UserFullName = x.ToUser.Name + ' ' + x.ToUser.Surname,
            //    SendDate = x.SendDate,
            //    LastMessageInfo = x.Message,
            //}).ToList();


            var chatPreviews = await _service.GetChatsPreviewAsync(UserId);

            return chatPreviews.Select(x => new GetContactsQueryResult
            {
                UserFullName = x.ToUser.Name + ' ' + x.ToUser.Surname,  // Karşı kullanıcının adı soyadı
                SendDate = x.SendDate,  // Son mesajın tarihi
                LastMessageInfo = x.Message, // Son mesajın ilk 20 karakteri
                ToUserId = x.ToUserId
            }).ToList();
        }
    }
}

