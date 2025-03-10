using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers;
using AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries;
using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcilKan.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BloodRequestController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllBloodRequest() // kan bağışları talep listesi sitenin ana sayfası
        {
            var values = await _mediator.Send(new GetBloodRequestQuery());
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMyBloodRequest() // sadece benim açtığım talepler ve donerleri
        {
            var values = await _mediator.Send(new GetMyBloodRequestQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBloodRequest(int id) 
        {
            var values = await _mediator.Send(new GetBloodRequestByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBloodRequest(CreateBloodRequestCommand command) // talep açma
        {
            await _mediator.Send(command);
            return Ok("Kan talebi oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBloodRequest(UpdateBloodRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kan talebi güncellendi");
        }


        [HttpPut]
        public async Task<IActionResult> CancelBloodRequest(CancelBloodRequestCommand command) // talep iptal etme
        {
            await _mediator.Send(command);
            return Ok("Kan talebi iptal edildi");
        }

        [HttpPut]
        public async Task<IActionResult> ExtendExpirationDate(ExtendExpirationDateBloodRequestCommand command) //talebi 1 gün uzat
        {
            await _mediator.Send(command);
            return Ok("Talebin Süresi 1 gün uzatıldı");
        }
        
        [HttpPut]
        public async Task<IActionResult> RejectDonor(RejectDonorCommand command) //talebi 1 gün uzat
        {
            await _mediator.Send(command);
            return Ok("Donör Bildirildi Bağış Yapılmadı !");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatByBloodRequestId(int id) 
        {
            var value = await _mediator.Send(new GetChatByBloodRequestIdQuery(id));
            return Ok(value);
        }

    }
}
      