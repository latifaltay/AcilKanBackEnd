using AcilKan.Application.Features.Mediator.Queries.DistrictQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDistrict()
        {
            var values = await _mediator.Send(new GetDistrictQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllHospitalByDistrictId(int id) 
        {
            var values = await _mediator.Send(new GetHospitalsByDistrictIdQuery(id));
            return Ok(values);  
        }

    }
}
