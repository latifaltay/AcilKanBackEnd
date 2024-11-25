using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.BloodDonationApproveCommands
{
    public class CreateBloodDonationApproveCommand : IRequest
    {
        public int BloodDontaionId { get; set; }
        public int RequestCreatorId { get; set; }
        public int DonorId { get; set; }
    }
}
