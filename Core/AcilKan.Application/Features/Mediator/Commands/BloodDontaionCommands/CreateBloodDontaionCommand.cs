using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands
{
    public class CreateBloodDontaionCommand : IRequest
    {
        //public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int BloodRequestId { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
    }
}
