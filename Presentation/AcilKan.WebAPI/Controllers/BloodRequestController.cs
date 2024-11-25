using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers;
using AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries;
using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BloodRequestController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllBloodRequest()
        {
            var values = await _mediator.Send(new GetBloodRequestQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBloodRequest(int id)
        {
            var values = await _mediator.Send(new GetBloodRequestByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBloodRequest(CreateBloodRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan talebi oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBloodRequest(UpdateBloodRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan talebi güncellendi");
        }


        [HttpPut]
        public async Task<IActionResult> CancelBloodRequest(CancelBloodRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan talebi iptal edildi");
        }

    }
}
      