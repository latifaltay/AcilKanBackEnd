using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.SupporterCommands
{
    public class CreateSupporterCommand : IRequest
    {
        public string CompanyName { get; set; }
        public string ImageUrl { get; set; }
    }
}
