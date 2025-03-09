using AcilKan.Application.Features.Mediator.Queries.UserInformationQueries;
using AcilKan.Application.Features.Mediator.Results.UserInformationResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;


namespace AcilKan.Application.Features.Mediator.Handlers.UserInformationHandlers
{
    public class GetHomePageChartByUserIdQueryHandler(IRepository<BloodDonation> _repository, IBloodDonationService _service) : IRequestHandler<GetHomePageChartByUserIdQuery, GetHomePageChartByUserIdQueryResult>
    {
        public async Task<GetHomePageChartByUserIdQueryResult> Handle(GetHomePageChartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            var totalDonationCount = await _service.GetCompletedDonationCountByUserIdAsync(userId);
            var lastDonationDate = await _service.GetLastCompletedDonationDateByUserIdAsync(userId);

            string lastDonationMessage;
            string nextDonationMessage;

            if (lastDonationDate == null)
            {
                lastDonationMessage = "Henüz bağış yapılmamış.";
                nextDonationMessage = "Bir bağış yapıldıktan sonra hesaplanacaktır.";
            }
            else
            {
                var lastDonation = lastDonationDate.Value.ToDateTime(TimeOnly.MinValue);
                var nextDonation = lastDonation.AddDays(90);

                lastDonationMessage = lastDonation.ToString("dd.MM.yyyy");
                nextDonationMessage = nextDonation.ToString("dd.MM.yyyy");
            }

            return new GetHomePageChartByUserIdQueryResult
            {
                DonationCount = totalDonationCount,
                LastDonationDate = lastDonationMessage,
                NextDonationDate = nextDonationMessage
            };

        }
    }
}
