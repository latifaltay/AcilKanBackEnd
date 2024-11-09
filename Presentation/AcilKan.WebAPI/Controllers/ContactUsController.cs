using AcilKan.Application.Features.Mediator.Commands.ContactUsCommands;
using AcilKan.Application.Features.Mediator.Queries.ContactUsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ContactUsList()
        {
            var values = await _mediator.Send(new GetContactUsQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactUs(int id)
        {
            var value = await _mediator.Send(new GetContactUsByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateContactUs(CreateContactUsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveContactUs(int id)
        {
            await _mediator.Send(new DeleteContactUsCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateContactUs(UpdateContactUsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
