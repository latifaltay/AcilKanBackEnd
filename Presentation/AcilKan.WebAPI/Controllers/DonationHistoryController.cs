using AcilKan.Application.Features.Mediator.Queries.DonationHistoryQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DonationHistoryController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDonationHistory(int id) 
        {
            var values = await _mediator.Send(new GetDonationHistoryByUserIdQuery());
            return Ok(values);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonationRequestHistory(int id)
        {
            var values = await _mediator.Send(new GetDonationRequestHistoryByUserIdQuery());
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonationSentHistory(int id)
        {
            var values = await _mediator.Send(new GetDonationSentHistoryByUserIdQuery());
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetDonationInfoHistory()
        {
            var values = await _mediator.Send(new GetDonationInfoQuery());
            return Ok(values);
        }

    }
}
