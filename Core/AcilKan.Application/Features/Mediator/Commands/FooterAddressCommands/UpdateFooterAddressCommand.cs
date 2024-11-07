using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class UpdateFooterAddressCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
