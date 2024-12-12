using AcilKan.Application.Features.Mediator.Queries.UserProfileQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}