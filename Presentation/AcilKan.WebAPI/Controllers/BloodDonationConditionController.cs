using AcilKan.Application.Features.Mediator.Commands.BloodDonationConditionCommands;
using AcilKan.Application.Features.Mediator.Queries.BloodDonationConditionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodDonationConditionController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BloodDonationConditionList()
        {
            var values = await _mediator.Send(new GetBloodDonationConditionQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBloodDonationCondition(int id)
        {
            var value = await _mediator.Send(new GetBloodDonationConditionByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBloodDonationCondition(CreateBloodDonationConditionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveBloodDonationCondition(int id)
        {
            await _mediator.Send(new DeleteBloodDonationConditionCommand(id));
            return Ok("Hakkımda Alanı başarıyla silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBloodDonationCondition(UpdateBloodDonationConditionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hakkımda Alanı Başarıyla Güncellendi!");
        }
    }
}
