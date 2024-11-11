using AcilKan.Application.Features.Mediator.Queries.AboutBloodDonationQueries;
using AcilKan.Application.Features.Mediator.Queries.CityQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCity() 
        {
            var values = await _mediator.Send(new GetCityQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var values = await _mediator.Send(new GetCityByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistrictsByCityId(int id)
        {
            var values = await _mediator.Send(new GetDistrictsByCityIdQuery(id));
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHospitalsByCityId(int id)
        {
            var values = await _mediator.Send(new GetHospitalsByCityIdQuery(id));
            return Ok(values);
        }

    }
}
