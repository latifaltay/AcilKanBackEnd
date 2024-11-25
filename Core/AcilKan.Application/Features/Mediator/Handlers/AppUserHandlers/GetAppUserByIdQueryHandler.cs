using AcilKan.Application.Features.Mediator.Queries.AppUserQueries;
using AcilKan.Application.Features.Mediator.Results.AppUserResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserByIdQueryHandler(UserManager<AppUser> _userManager, IAppUserService _service) : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
    {
        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            //AppUser appUser = await _userManager.FindByIdAsync(request.Id.ToString());

            AppUser appUser = await _service.GetUsersWithDetailsByIdAsync(request.Id);

            return new GetAppUserByIdQueryResult
            {
                Id = appUser.Id,
                FullName = appUser.Name + " " +appUser.Surname,
                UserName = appUser.UserName,
                Email = appUser.Email,
                PhoneNumber = appUser.PhoneNumber,  
                BloodGroup = appUser.BloodGroup,
                Gender = appUser.Gender,
                City = appUser.City.Name,
                District = appUser.District.Name,   
            };
        }
    }
}