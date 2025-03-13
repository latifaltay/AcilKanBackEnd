using AcilKan.Application.Features.Mediator.Commands.BloodDonationCommands;
using FluentValidation;

namespace AcilKan.Application.ValidationRules.FluentValidation.Validators.BloodDonationValidators
{
    public class MarkAsArrivedCommandValidator : AbstractValidator<MarkAsArrivedCommand>
    {
        public MarkAsArrivedCommandValidator()
        {
            RuleFor(x => x.BloodDonationId).GreaterThan(0).WithMessage("Geçerli bir bağış ID girin.");
        }
    }
}
