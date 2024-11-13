using AcilKan.Application.Features.Mediator.Queries.DonationHistoryQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DonationHistoryController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDonationHistory(int id) 
        {
            var values = await _mediator.Send(new GetDonationHistoryByUserIdQuery());
            return Ok(values);  
        }
    }
}
