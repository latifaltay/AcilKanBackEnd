using AcilKan.Application.Features.Mediator.Commands.ChatCommands;
using AcilKan.Application.Features.Mediator.Queries.ChatQueries;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.WebAPI.Hubs;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController(IMediator _mediator, IHubContext<ChatHub> _hubContext) : ControllerBase
    {

        //[HttpGet]
        //public async Task<IActionResult> GetUsers()
        //{
        //    List<AppUser> users = await context.Users.OrderBy(p => p.Name).ToListAsync();
        //    return Ok(users);
        //}

        [HttpGet]
        public async Task<IActionResult> GetChats(int toUserId) 
        {
            var values = await _mediator.Send(new GetChatsQuery(toUserId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageCommand command)
        {
            // Komutu gönder (iç işleme)
            await _mediator.Send(command);

            // Kullanıcı ID'si ile bağlantı ID'sini bulma
            string connectionId = ChatHub.Users.FirstOrDefault(p => p.Value == command.ToUserId.ToString()).Key;

            if (!string.IsNullOrEmpty(connectionId))
            {
                // Bağlantı ID'si ile mesajı gönder
                await _hubContext.Clients.Client(connectionId).SendAsync(command.ToUserId.ToString(), command.Message);
            }

            return Ok("Mesaj gönderildi");
        }

    }
}
