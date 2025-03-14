using MediatR;

namespace AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands
{
    public class MarkAsDonatedCommand : IRequest<bool>
    {
        public int BloodDonationId { get; set; }
        public int? UnitsDonated { get; set; } = 1; // Kaç ünite bağışladı? 1 2 3 gibi olabilitesi var şimdiden düzenlendi belki gerek kalmaz
    }
}
