using AcilKan.Application.Features.Mediator.Commands.ChatCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace AcilKan.Application.Features.Mediator.Handlers.ChatHandlers
{
    public class SendMessageCommandHandler(IRepository<Chat> _repository) : IRequestHandler<SendMessageCommand>
    {
        
        public async Task Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            await _repository.CreateAsync(new Chat
            {
                Message = request.Message,
                SendDate = DateTime.UtcNow,
                ToUserId = request.ToUserId,
                FromUserId = userId,
            });

            //string connectionId = ChatHub.Users.FirstOrDefault(p => p.Value == chat.ToUserId).Key;


            // mediator tasarım deseninde insert operasyonlarında geriye bir şey dönmüyorum demenin best practice yoluymuş araştırılacak
            //return Unit.Value;
        }
    }
}
