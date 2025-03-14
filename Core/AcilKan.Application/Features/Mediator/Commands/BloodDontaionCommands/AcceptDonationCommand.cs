using MediatR;

namespace AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands
{
    public class AcceptDonationCommand : IRequest<bool>
    {
        public int BloodDonationId { get; set; }
    }
}
