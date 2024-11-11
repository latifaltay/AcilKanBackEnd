using AcilKan.Application.Features.Mediator.Queries.BloodGroupQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodGroupController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var values = await _mediator.Send(new GetBloodGroupQuery());
            return Ok(values);
        }
    }
}
