﻿using AcilKan.Application.DTOs.LoginRegisterOperations;
using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler(UserManager<AppUser> _userManager) : IRequestHandler<CreateAppUserCommand>
    {

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = new AppUser 
            {
                UserName = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                BloodGroup = request.BloodGroup,
                Gender = request.Gender,
                CityId = request.CityId,
                DistrictId = request.DistrictId,
                RegisterDate = DateTime.Now.Date,
                BirthDate = request.BirthDate, 
            };

            var result = await _userManager.CreateAsync(appUser, request.Password);

        }
    }
}

