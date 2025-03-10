using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands
{
    public class ExtendExpirationDateBloodRequestCommand : IRequest<string>
    {
        public int RequestId { get; set; }
    }

}
