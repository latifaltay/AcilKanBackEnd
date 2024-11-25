using AcilKan.Application.Features.Mediator.Commands.BloodDonationApproveCommands;
using AcilKan.Application.Features.Mediator.Handlers.BloodDonationApproveHandlers;
using AcilKan.Application.Features.Mediator.Queries.BloodDontaionApproveQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BloodDonationApproveController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBloodDonationApprove() 
        {
            var values = await _mediator.Send(new GetBloodDonationApproveForAdminQuery());
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetBloodDonationApproveByDonorId()
        {
            var values = await _mediator.Send(new GetBloodDonationApproveByDonorIdQuery());
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetBloodDonationApproveByRequesterId()
        {
            var values = await _mediator.Send(new GetBloodDonationApproveByRequesterIdQuery());
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBloodDonationApproveForRequester(UpdateBloodDonationApproveForRequesterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan talebini oluşturan kullanıcı onay güncellemesini başarılı bir şekilde gerçekleştirdi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBloodDonationApproveForDonor(UpdateBloodDonationApproveForDonorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Donor onay güncellemesini başarılı bir şekilde gerçekleştirdi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBloodDonationApproveForDonor(CreateBloodDonationApproveCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
