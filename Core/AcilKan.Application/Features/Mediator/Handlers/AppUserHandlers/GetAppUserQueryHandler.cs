using AcilKan.Application.Features.Mediator.Queries.AppUserQueries;
using AcilKan.Application.Features.Mediator.Results.AppUserResults;
using AcilKan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserQueryHandler(UserManager<AppUser> _userManager) : IRequestHandler<GetAppUserQuery, List<GetAppUserQueryResult>>
    {
        public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync(cancellationToken);

            var result = users.Select(user => new GetAppUserQueryResult
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                BloodGroup = user.BloodGroup,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl,
            }).ToList();

            return result;
        }
    }
}
