using AcilKan.Application.Features.Mediator.Commands.BloodDonationCommands;
using AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands;
using AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BloodDonationController(IMediator _mediator) : ControllerBase
    {
 
        [HttpGet]
        public async Task<IActionResult> GetMyBloodDonations()
        {
            var values = await _mediator.Send(new GetMyBloodDonationsQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBloodDonation(CreateBloodDontaionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan Bağışı oluşturuldu");
        }


        [HttpPut]
        public async Task<IActionResult> CancelBloodDonation(CancelBloodDonationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan Bağışı iptal edildi");
        }
        
        [HttpPost("arrived")]  // ben geldim olarak işaretleme
        public async Task<IActionResult> MarkAsArrived(MarkAsArrivedCommand command)
        {
            await _mediator.Send(command);
            return Ok("Bağışçı merkeze geldi olarak işaretlendi.");
        }

        [HttpPost("donated")] // bağış yapıldı olarak işaretleme
        public async Task<IActionResult> MarkAsDonated(MarkAsDonatedCommand command)
        {
            await _mediator.Send(command);
            return Ok("Bağış başarıyla tamamlandı.");
        }

        [HttpPost("accept-donation")] // bağış yapıldı olarak onaylama requester tarafından
        public async Task<IActionResult> AcceptDonation(AcceptDonationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Bağış başarıyla kabul edildi.");
        }
    }
}
