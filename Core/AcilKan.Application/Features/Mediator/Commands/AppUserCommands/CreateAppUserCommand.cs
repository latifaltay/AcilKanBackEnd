using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.AppUserCommands
{
    public class CreateAppUserCommand : IRequest
    {
        public string UserName { get; set; } // IdentityUser'dan gelen kullanıcı adı
        public string Email { get; set; }    // IdentityUser'dan gelen e-posta
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BloodGroup { get; set; }
        public string ImageUrl { get; set; }
        public bool Gender { get; set; }
    }
}


