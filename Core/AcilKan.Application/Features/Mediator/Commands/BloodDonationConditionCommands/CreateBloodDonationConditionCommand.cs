using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.BloodDonationConditionCommands
{
    public class CreateBloodDonationConditionCommand : IRequest
    {
        public string Title { get; set; }
    }
}
