using AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries;
using AcilKan.Application.Features.Mediator.Queries.UserProfileQueries;
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
    public class UserProfileController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserProfileInfo()
        {
            var value = await _mediator.Send(new GetUserProfileInfoByUserIdQuery());
            return Ok(value);
        }



        [Authorize] // JWT gerektirir

        [HttpGet("donation-stats")]
        public async Task<IActionResult> GetUserDonationStats()
        {
            // Kullanıcı ID'sini JWT Token'dan al
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var query = new GetUserDonationStatsQuery { UserId = userId };
            var result = _mediator.Send(query);

            return Ok(result);
        }


    }
}