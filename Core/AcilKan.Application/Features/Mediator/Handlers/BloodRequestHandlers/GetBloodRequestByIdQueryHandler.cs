using AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries;
using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class GetBloodRequestByIdQueryHandler : IRequestHandler<GetBloodRequestByIdQuery, GetBloodRequestByIdQueryResult>
    {

        private readonly IRepository<BloodRequest> _bloodRequestRepository;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<BloodGroup> _bloodGroupRepository;
        private readonly IRepository<Hospital> _hospitalRepository;

        public GetBloodRequestByIdQueryHandler(
            IRepository<BloodRequest> bloodRequestRepository,
            IRepository<AppUser> userRepository,
            IRepository<BloodGroup> bloodGroupRepository,
            IRepository<Hospital> hospitalRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
            _userRepository = userRepository;
            _bloodGroupRepository = bloodGroupRepository;
            _hospitalRepository = hospitalRepository;
        }

        public Task<GetBloodRequestByIdQueryResult> Handle(GetBloodRequestByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<GetBloodRequestByIdQueryResult> Handle(GetBloodRequestByIdQuery request, CancellationToken cancellationToken)
        //{
        //    var bloodRequest = await _bloodRequestRepository.GetByIdAsync(request.Id);

        //    var appUser = await _userRepository.GetByIdAsync(bloodRequest.AppUserId);

        //    var bloodGroup = await _bloodGroupRepository.GetByIdAsync(bloodRequest.BloodGroupId);
        //    var hospital = await _hospitalRepository.GetByIdAsync(bloodRequest.HospitalId);

        //    return new GetBloodRequestByIdQueryResult
        //    {
        //        Id = bloodRequest.Id,
        //        AppUserId = bloodRequest.AppUserId,
        //        AppUserName = appUser?.FirstName,
        //        AppUserSurName = appUser?.LastName,
        //        BloodGroupId = bloodRequest.BloodGroupId,
        //        BloodGroupName = bloodGroup?.GroupName,
        //        HospitalId = bloodRequest.HospitalId,
        //        HospitalName = hospital?.Name,
        //        IsActive = bloodRequest.IsActive,
        //        CreatedDate = bloodRequest.CreatedDate,
        //        PatientName = bloodRequest.PatientName,
        //        PatientSurname = bloodRequest.PatientSurname,
        //    };

        //}
    }
}