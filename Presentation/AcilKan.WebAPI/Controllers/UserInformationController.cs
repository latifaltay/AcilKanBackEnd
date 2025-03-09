using AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries;
using AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries;
using AcilKan.Application.Features.Mediator.Queries.UserInformationQueries;
using AcilKan.Application.Features.Mediator.Results.UserInformationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Claims;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserInformationController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserProfileInfo()
        {
            var value = await _mediator.Send(new GetUserProfileInfoByUserIdQuery());
            return Ok(value);
        }


        [HttpGet]
        public async Task<IActionResult> GetHomePageChartByUserId() 
        {
            var value = await _mediator.Send(new GetHomePageChartByUserIdQuery());
            return Ok(value);
        }
    }
}