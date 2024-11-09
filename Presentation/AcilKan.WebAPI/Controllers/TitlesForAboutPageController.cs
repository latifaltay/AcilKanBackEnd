using AcilKan.Application.Features.Mediator.Commands.TitlesForAboutPageCommands;
using AcilKan.Application.Features.Mediator.Queries.TitlesForAboutPageQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesForAboutPageController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TitlesForAboutPageList()
        {
            var values = await _mediator.Send(new GetTitlesForAboutPageQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitlesForAboutPage(int id)
        {
            var value = await _mediator.Send(new GetTitlesForAboutPageByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTitlesForAboutPage(CreateTitlesForAboutPageCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveTitlesForAboutPage(int id)
        {
            await _mediator.Send(new DeleteTitlesForAboutPageCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTitlesForAboutPage(UpdateTitlesForAboutPageCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
