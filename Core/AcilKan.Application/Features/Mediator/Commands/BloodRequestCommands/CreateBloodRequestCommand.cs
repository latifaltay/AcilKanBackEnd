using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands
{
    public class CreateBloodRequestCommand : IRequest
    {
        public int HospitalId { get; set; }
        public int BloodGroupId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientTC { get; set; }
        public bool? PatientGender { get; set; }
        public DateTime PatientBirtDate { get; set; }
        public int RequiredUnits { get; set; }
        public bool IsIndependentDonation { get; set; }
        public int DemandReasonTypeId { get; set; }
    }
}
