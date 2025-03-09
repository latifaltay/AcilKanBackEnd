﻿using AcilKan.Application.Extensions;
using AcilKan.Application.Features.Mediator.Queries.UserInformationQueries;
using AcilKan.Application.Features.Mediator.Results.UserInformationResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.UserInformationHandlers
{
    public class GetUserProfileInfoByUserIdQueryHandler(IRepository<AppUser> _repository, IUserProfileService _service, IBloodDonationService _bloodService) : IRequestHandler<GetUserProfileInfoByUserIdQuery, GetUserProfileInfoByUserIdQueryResult>
    {
        public async Task<GetUserProfileInfoByUserIdQueryResult> Handle(GetUserProfileInfoByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            var values = await _service.GetUserProfileWithDetailAsync(userId);
            var totalDonationCount = await _bloodService.GetCompletedDonationCountByUserIdAsync(userId);


            var lastDonation = values.BloodDonations != null && values.BloodDonations.Any()
                 ? values.BloodDonations
                     .OrderByDescending(x => x.DonationCompletionDate)
                     .FirstOrDefault()?.DonationCompletionDate?.ToShortDateString() 
                 : "Daha önce hiç bağış yapılmamış";


            return new GetUserProfileInfoByUserIdQueryResult
            {
                FullName = values.Name + ' ' + values.Surname,
                Email = values.Email,
                PhoneNumber = values.PhoneNumber,
                BloodGroupName = ((BloodGroupType)values.BloodGroup).GetDescription(),
                City = values.City.Name,
                District = values.District.Name,
                LastDonation = lastDonation,
                TotalDonationCount = totalDonationCount
            };
        }
    }
}
