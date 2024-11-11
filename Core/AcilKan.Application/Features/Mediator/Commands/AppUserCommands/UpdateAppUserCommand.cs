using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.AppUserCommands
{
    public class UpdateAppUserCommand : IRequest
    {
        public int Id { get; set; }         // IdentityUser'dan gelen Id
        public string Email { get; set; }    // IdentityUser'dan gelen e-posta
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }

    }
}
