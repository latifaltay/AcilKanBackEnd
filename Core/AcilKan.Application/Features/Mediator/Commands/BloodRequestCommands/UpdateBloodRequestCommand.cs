using AcilKan.Domain.Enums;
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
        public bool IsIndependentDonation { get; set; } // Bağımsız bağış mümkün mü?
        public int RequiredUnits { get; set; } // Kaç ünite kan gerekiyor?
        public bool? PatientGender { get; set; } // Hasta cinsiyeti (Erkek: true, Kadın: false)
        public int HospitalId { get; set; } // Hastanın Yattığı Hastane
        public DemandReasonType? DemandReason { get; set; } // Talep Sebebi
    }
}
