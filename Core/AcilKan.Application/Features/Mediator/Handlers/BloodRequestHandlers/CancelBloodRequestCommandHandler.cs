using AcilKan.Application.Features.Mediator.Commands.BloodRequestCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums; // ✅ Enum'un olduğu namespace eklenmeli
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class CancelBloodRequestCommandHandler(IRepository<BloodRequest> _repository)
        : IRequestHandler<CancelBloodRequestCommand>
    {
        public async Task Handle(CancelBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null) // ✅ Eğer `Id` yanlışsa hata fırlat
                throw new Exception("Talep bulunamadı.");

            value.IsActive = false;
            value.Status = BloodRequestStatus.CanceledByAdmin; // ✅ Enum kullanımı
            await _repository.UpdateAsync(value);
        }
    }
}
