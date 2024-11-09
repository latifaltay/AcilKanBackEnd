using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.AboutBloodDonationCommands
{
    public class CreateAboutBloodDonationCommand : IRequest
    {
        public string ImageUrl { get; set; }
    }
}
