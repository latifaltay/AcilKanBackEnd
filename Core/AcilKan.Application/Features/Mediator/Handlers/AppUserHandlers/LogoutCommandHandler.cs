using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class LogoutCommandHandler(UserManager<AppUser> _userManager, IJwtTokenService _jwtTokenService, IHttpContextAccessor _httpContextAccessor)
     : IRequestHandler<LogoutCommand, bool>
    {
        public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            //var userId = await _userManager
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return false;

            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return await _jwtTokenService.LogoutAsync(user, token);
        }
    }
}
