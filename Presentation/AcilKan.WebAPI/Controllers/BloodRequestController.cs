using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestController(IMediator _mediator) : ControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetBloodRequest() 
        //{
        //    var value = await _mediator.Send(new );
        //}
    }
}
