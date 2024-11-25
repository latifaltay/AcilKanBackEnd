using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.BloodDonationApproveCommands
{
    public class UpdateBloodDonationApproveForRequesterCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
        public bool? IsDonorApproved { get; set; } // Donor'ün onayı
        public bool? IsRequestCreatorApproved { get; set; } // Request creator'ın onayı
    }
}
