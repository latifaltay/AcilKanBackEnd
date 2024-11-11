using AcilKan.Application.DTOs.LoginRegisterOperations;
using AcilKan.Application.DTOs.TokenDtos;
using AcilKan.Application.Features.Mediator.Commands.AboutBloodDonationCommands;
using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;
using AcilKan.Application.Features.Mediator.Queries.AboutBloodDonationQueries;
using AcilKan.Application.Features.Mediator.Queries.AppUserQueries;
using AcilKan.Domain.Entities;
using AcilKan.Persistence.Services;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppUserController(IMediator _mediator, JwtTokenService _jwtTokenService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var value = await _mediator.Send(new GetAppUserQuery());
            return Ok(value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var value = await _mediator.Send(new GetAppUserByIdQuery(id));
            return Ok(value);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand command)
        {
            await _mediator.Send(command);
            return Ok("Parola güncellendi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo(UpdateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı bilgileri güncellendi");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı silindi");
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı oluşturuldu");
        }


        [HttpGet]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var result = await _mediator.Send(new ForgotPasswordQuery(email));
            return Ok(new { Token = result.Token });
        }


        [HttpPost]
        public async Task<IActionResult> ChangePasswordUsingToken(ChangePasswordUsingTokenCommand command)
        {
            await _mediator.Send(command);
            return Ok("Parola değiştirildi");
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            return Ok(new { message = result.Message, accessToken = result.AccessToken, refreshToken = result.RefreshToken});
        }


        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto request)
        {

            var tokenResult = await _jwtTokenService.RefreshAccessToken(request.RefreshToken);
            return Ok(tokenResult);
        }

    }
}
