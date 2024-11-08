using AcilKan.Application.Features.Mediator.Commands.BannerCommands;
using AcilKan.Application.Features.Mediator.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _mediator.Send(new GetBannerQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _mediator.Send(new GetBannerByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _mediator.Send(new DeleteBannerCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
