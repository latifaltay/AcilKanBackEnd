using AcilKan.Application.Features.Mediator.Commands.DonationBenefitCommands;
using AcilKan.Application.Features.Mediator.Queries.DonationBenefitQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationBenefitsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> DonationBenefitList()
        {
            var values = await _mediator.Send(new GetDonationBenefitQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonationBenefit(int id)
        {
            var value = await _mediator.Send(new GetDonationBenefitByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateDonationBenefit(CreateDonationBenefitCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveDonationBenefit(int id)
        {
            await _mediator.Send(new DeleteDonationBenefitCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDonationBenefit(UpdateDonationBenefitCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
