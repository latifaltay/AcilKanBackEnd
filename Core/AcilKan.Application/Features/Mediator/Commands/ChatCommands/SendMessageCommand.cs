using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.ChatCommands
{
    public class SendMessageCommand : IRequest
    {
        public int ToUserId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
