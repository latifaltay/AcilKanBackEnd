using MediatR;

namespace AcilKan.Application.Features.Mediator.Commands.BloodDonationCommands
{
    public class MarkAsArrivedCommand : IRequest<bool>
    {
        public int BloodDonationId { get; set; }
    }
}
