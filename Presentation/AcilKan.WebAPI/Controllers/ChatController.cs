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


        // bu endpoint son mesajlarım kısmını getiriyor
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var values = await _mediator.Send(new GetContactsQuery());
            return Ok(values);
        }


        [HttpGet("{toUserId}")]
        public async Task<IActionResult> GetChats(int toUserId)
        {
            var values = await _mediator.Send(new GetChatsToUserIdQuery(toUserId));
            return Ok(values);
        }


        // mesaj gönderme refaktör edilecek
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageCommand command)
        {
            await _mediator.Send(command);

            string connectionId = ChatHub.Users.FirstOrDefault(p => p.Value == command.ToUserId.ToString()).Key;

            if (!string.IsNullOrEmpty(connectionId))
            {
                await _hubContext.Clients.Client(connectionId).SendAsync(command.ToUserId.ToString(), command.Message);
            }

            return Ok("Mesaj gönderildi");
        }

    }
}
