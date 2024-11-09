using AcilKan.Application.Features.Mediator.Commands.ArticlesForAboutPageCommands;
using AcilKan.Application.Features.Mediator.Queries.ArticlesForAboutPageQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesForAboutPageController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GeneralConditionsForBloodDonationList()
        {
            var values = await _mediator.Send(new GetArticlesForAboutPageQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneralConditionsForBloodDonation(int id)
        {
            var value = await _mediator.Send(new GetArticlesForAboutPageByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateGeneralConditionsForBloodDonation(CreateArticlesForAboutPageCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveGeneralConditionsForBloodDonation(int id)
        {
            await _mediator.Send(new DeleteArticlesForAboutPageCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateGeneralConditionsForBloodDonation(UpdateArticlesForAboutPageCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
