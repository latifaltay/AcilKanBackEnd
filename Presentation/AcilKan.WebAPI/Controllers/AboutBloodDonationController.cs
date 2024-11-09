using AcilKan.Application.Features.Mediator.Commands.AboutBloodDonationCommands;
using AcilKan.Application.Features.Mediator.Queries.AboutBloodDonationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutBloodDonationController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AboutBloodDonationList()
        {
            var values = await _mediator.Send(new GetAboutBloodDonationQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutBloodDonation(int id)
        {
            var value = await _mediator.Send(new GetAboutBloodDonationByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAboutBloodDonation(CreateAboutBloodDonationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveAboutBloodDonation(int id)
        {
            await _mediator.Send(new DeleteAboutBloodDonationCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAboutBloodDonation(UpdateAboutBloodDonationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
