using AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDontaionHandlers
{
    public class MarkAsDonatedCommandHandler : IRequestHandler<MarkAsDonatedCommand, bool>
    {
        private readonly IBloodDonationService _bloodDonationRepository;
        private readonly IRepository<BloodDonation> _repository;

        public MarkAsDonatedCommandHandler(IBloodDonationService bloodDonationRepository, IRepository<BloodDonation> repository)
        {
            _bloodDonationRepository = bloodDonationRepository;
            _repository = repository;
        }

        public async Task<bool> Handle(MarkAsDonatedCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            var bloodDonation = await _bloodDonationRepository.GetByIdAsync(request.BloodDonationId);

            if (bloodDonation == null ||
                bloodDonation.DonorId != userId ||
                !bloodDonation.IsActive ||
                bloodDonation.Status != BloodDonationStatus.ArrivedAtDonationPoint)
            {
                throw new Exception("Geçersiz ya da yetkisiz işlem.");
            }

            bloodDonation.Status = BloodDonationStatus.CompletedByDonor; // Bağış tamamlandı
            bloodDonation.UnitsDonated = request.UnitsDonated; // Bağışçının geldiğini işaretle
            await _bloodDonationRepository.UpdateAsync(bloodDonation);
            return true;
        }
    }
}
