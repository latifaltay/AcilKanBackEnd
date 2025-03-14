using AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands;
using FluentValidation;

namespace AcilKan.Application.ValidationRules.FluentValidation.Validators.BloodDonationValidators
{
    public class MarkAsDonatedCommandValidator : AbstractValidator<MarkAsDonatedCommand>
    {
        public MarkAsDonatedCommandValidator()
        {
            RuleFor(x => x.BloodDonationId).GreaterThan(0).WithMessage("Geçerli bir bağış ID girin.");
            RuleFor(x => x.UnitsDonated)
                      .Must(value => value == null || value == 1 || value == 2 || value == 3)
                      .WithMessage("Bağış ünite değeri yalnızca 1, 2 veya 3 olabilir.");
        }
    }
}
