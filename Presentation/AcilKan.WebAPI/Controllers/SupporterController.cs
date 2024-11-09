using AcilKan.Application.Features.Mediator.Commands.SupporterCommands;
using AcilKan.Application.Features.Mediator.Queries.SupporterQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupporterController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SupporterList()
        {
            var values = await _mediator.Send(new GetSupporterQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupporter(int id)
        {
            var value = await _mediator.Send(new GetSupporterByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSupporter(CreateSupporterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveSupporter(int id)
        {
            await _mediator.Send(new DeleteSupporterCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateSupporter(UpdateSupporterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
