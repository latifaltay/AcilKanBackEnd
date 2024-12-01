using AcilKan.Application.Features.Mediator.Queries.ProfileQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileInfo(int id)
        {
            var value = await _mediator.Send(new GetProfileInfoByUserIdQuery(id));
            return Ok(value);
        }
    }

}
