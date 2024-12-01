using AcilKan.Application.DTOs.LoginRegisterOperations;
using AcilKan.Application.DTOs.TokenDtos;
using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;
using AcilKan.Application.Features.Mediator.Queries.AppUserQueries;
using AcilKan.Domain.Entities;
using AcilKan.Persistence.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IMediator _mediator, JwtTokenService _jwtTokenService) : ControllerBase
    {

    }

}
