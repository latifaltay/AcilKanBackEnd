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

            // **18 yaş altındaki kullanıcıları engelleme**
            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Doğum tarihi zorunludur.")
                .Must(BeAtLeast18YearsOld).WithMessage("18 yaşından küçükler kayıt olamaz.");
        }

        private bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            return birthDate <= DateTime.UtcNow.AddYears(-18);
        }
    }
}
