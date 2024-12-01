using AcilKan.Application.Extensions;
using AcilKan.Application.Features.Mediator.Queries.ProfileQueries;
using AcilKan.Application.Features.Mediator.Results.ProfileResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.ProfileHandlers
{
    public class GetProfileInfoByUserIdQueryHandler(IRepository<AppUser> _repository) : IRequestHandler<GetProfileInfoByUserIdQuery, GetProfileInfoByUserIdQueryResult>
    {
        public async Task<GetProfileInfoByUserIdQueryResult> Handle(GetProfileInfoByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.UserId);
            return new GetProfileInfoByUserIdQueryResult 
            {
                FullName = values.Name + ' ' + values.Surname,
                Email = values.Email,
                PhoneNumber = values.PhoneNumber,
                BloodGroup = values.BloodGroup.GetDescription(),
                //City = values.City.Name,
                //District = values.District.Name,
            };

        }
    }
}
