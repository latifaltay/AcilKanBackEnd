using FluentValidation;
using AcilKan.Application.DTOs;
using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;

namespace AcilKan.Application.ValidationRules.FluentValidation.Validators.AppUserValidators
{
    public class CreateAppUserCommandValidator : AbstractValidator<CreateAppUserCommand>
    {
        public CreateAppUserCommandValidator()
        {
            RuleFor(x => x.TC)
                .NotEmpty().WithMessage("TC Kimlik Numarası zorunludur.")
                .Length(11).WithMessage("TC Kimlik Numarası 11 haneli olmalıdır.")
                .Matches("^[0-9]+$").WithMessage("TC Kimlik Numarası sadece rakamlardan oluşmalıdır.");

            // Telefon Numarası Validasyonu
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası zorunludur.")
                .Matches(@"^(\+90|90|0)?[0-9]{10}$").WithMessage("Telefon numarası geçerli formatta olmalıdır. (Örn: 905438194976 veya 05438194976)");

        }
    }
}
