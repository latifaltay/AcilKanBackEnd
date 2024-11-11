using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands
{
    public class UpdateBloodRequestCommand : IRequest
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int BloodGroupId { get; set; }
        public int PatientName { get; set; }
        public int PatientSurname { get; set; }
    }
}
