using AcilKan.Application.DTOs.LoginRegisterOperations;
using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;
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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginCommandHandler(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new LoginResult
                {
                    Message = "Kullanıcı bulunamadı.",
                    AccessToken = null,
                    RefreshToken = null
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                return new LoginResult
                {
                    Message = "Yanlış şifre.",
                    AccessToken = null,
                    RefreshToken = null
                };
            }

            var tokenResult = await _jwtTokenService.GenerateTokens(user);

            return new LoginResult
            {
                Message = "Giriş başarılı.",
                AccessToken = tokenResult.AccessToken,
                RefreshToken = tokenResult.RefreshToken,
                IsOnline = true
            };
        }
    }
}
