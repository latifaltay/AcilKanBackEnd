using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.BloodDonationCommands
{
    public class MarkAsArrivedCommandHandler : IRequestHandler<MarkAsArrivedCommand, bool>
    {
        private readonly IBloodDonationService _bloodDonationRepository;
        private readonly IRepository<BloodDonation> _repository;

        

        public MarkAsArrivedCommandHandler(IBloodDonationService bloodDonationRepository, IRepository<BloodDonation> repository)
        {
            _bloodDonationRepository = bloodDonationRepository;
            _repository = repository;
        }

        public async Task<bool> Handle(MarkAsArrivedCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            var bloodDonation = await _bloodDonationRepository.GetByIdAsync(request.BloodDonationId);
   
            if (bloodDonation == null || bloodDonation.DonorId != userId || bloodDonation.IsActive==false || bloodDonation.Status != BloodDonationStatus.Requested)
            {
                throw new Exception("Geçersiz yada yetkisiz işlem.");
            }

            bloodDonation.Status = BloodDonationStatus.ArrivedAtDonationPoint; // Bağışçının geldiğini işaretle
        
            await _bloodDonationRepository.UpdateAsync(bloodDonation);
            return true;
        }
    }
}
