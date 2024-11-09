using AcilKan.Application.Features.Mediator.Commands.MissionCommands;
using AcilKan.Application.Features.Mediator.Queries.MissionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> MissionList()
        {
            var values = await _mediator.Send(new GetMissionQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMission(int id)
        {
            var value = await _mediator.Send(new GetMissionByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateMission(CreateMissionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveMission(int id)
        {
            await _mediator.Send(new DeleteMissionCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMission(UpdateMissionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
