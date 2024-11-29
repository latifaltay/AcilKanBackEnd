using AcilKan.Domain.Enums;
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
        public string Email { get; set; }    // IdentityUser'dan gelen e-posta
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public BloodGroupType BloodGroup { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}


