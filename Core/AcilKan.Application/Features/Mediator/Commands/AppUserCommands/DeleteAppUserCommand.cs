using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.AppUserCommands
{
    public class DeleteAppUserCommand(string email) : IRequest
    {
        public string Email { get; set; } = email;
    }
}
