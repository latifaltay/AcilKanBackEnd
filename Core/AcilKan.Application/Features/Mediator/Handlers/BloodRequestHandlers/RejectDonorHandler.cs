using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using Newtonsoft.Json.Linq;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class RejectDonorHandler : IRequestHandler<RejectDonorCommand, string>
    {
        private readonly IRepository<BloodDonation> _repository;
        private readonly IBloodDonationService _bloodDonationService;
        private readonly IDateTimeService _dateTimeService;

        public RejectDonorHandler(IRepository<BloodDonation> repository, IDateTimeService dateTimeService, IBloodDonationService bloodDonationService   )
        {
            _repository = repository;
            _dateTimeService = dateTimeService;
            _bloodDonationService = bloodDonationService;
        }

        public async Task<string> Handle(RejectDonorCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            var donation = await _bloodDonationService.GetBloodDonationWithRequestAsync(request.BloodDonationId);

            if (donation == null || !donation.IsActive)
                throw new Exception("Bağış bulunamadı veya iptal edilemez.");
   
            // **Bağışın bağlı olduğu isteğin sahibiyle (RequesterId) doğrulama yapılıyor**
            if (donation.BloodRequest == null || donation.BloodRequest.RequesterId != userId)
                throw new Exception("Bu bağışı iptal etme yetkiniz yok.");

            // **Daha önceden Onaylanmış Bir Donörü Reddedemezsiniz !
            if (donation.Status == BloodDonationStatus.ApprovedByRequester )
                throw new Exception("Daha önceden Onaylanmış Bir Donörü Reddedemezsiniz !");

            // Status değiştiriliyor
            donation.Status = BloodDonationStatus.RejectedByRequester;
            donation.LastUpdatedDate = _dateTimeService.GetCurrentTimeInTurkey();
       

            await _repository.UpdateAsync(donation);
            return "Döner bağış yapmadı olarak bildirildi.";
        }
    }
}
