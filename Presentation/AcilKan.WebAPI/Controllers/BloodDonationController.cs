using AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands;
using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Claims;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BloodDonationController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBloodDonations()
        {
            var values = await _mediator.Send(new GetBloodDonationQuery());
            return Ok(values);
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

        [HttpPost]
        public async Task<IActionResult> CreateBloodDonation(CreateBloodDontaionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan Bağışı oluşturuldu");
        }

        [HttpPut]


        public async Task<IActionResult> CancelBloodDonation(CancelBloodDonationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan Bağışı iptal edildi");
        }

    }
}
