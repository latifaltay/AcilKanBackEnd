using AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDontaionHandlers
{
    public class AcceptDonationCommandHandler : IRequestHandler<AcceptDonationCommand, bool>
    {
        private readonly IBloodDonationService _bloodDonationRepository;
        private readonly IRepository<BloodDonation> _repository;

        public AcceptDonationCommandHandler(IBloodDonationService bloodDonationRepository, IRepository<BloodDonation> repository)
        {
            _bloodDonationRepository = bloodDonationRepository;
            _repository = repository;
        }

        public async Task<bool> Handle(AcceptDonationCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            var bloodDonation = await _bloodDonationRepository.GetByIdAsync(request.BloodDonationId);

            if (bloodDonation == null ||
                bloodDonation.BloodRequest.RequesterId != userId ||
                !bloodDonation.IsActive ||
                (bloodDonation.Status != BloodDonationStatus.CompletedByDonor && bloodDonation.Status != BloodDonationStatus.Requested ))
            {
                throw new Exception("Geçersiz ya da yetkisiz işlem.");
            }

            bloodDonation.Status = BloodDonationStatus.ApprovedByRequester; // Bağış kabul edildi
            await _bloodDonationRepository.UpdateAsync(bloodDonation);
            return true;
        }
    }
}
