using AcilKan.Application.Features.Mediator.Commands.AboutUsCommands;
using AcilKan.Application.Features.Mediator.Queries.AboutUsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> AboutUsList()
        {
            var values = await _mediator.Send(new GetAboutUsQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutUs(int id)
        {
            var value = await _mediator.Send(new GetAboutUsByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAboutUs(CreateAboutUsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveAboutUs(int id)
        {
            await _mediator.Send(new DeleteAboutUsCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAboutUs(UpdateAboutUsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}

