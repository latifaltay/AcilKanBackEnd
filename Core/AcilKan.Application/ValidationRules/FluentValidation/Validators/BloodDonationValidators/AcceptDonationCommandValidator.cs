using AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands;
using FluentValidation;

namespace AcilKan.Application.ValidationRules.FluentValidation.Validators.BloodDonationValidators
{
    public class AcceptDonationCommandValidator : AbstractValidator<AcceptDonationCommand>
    {
        public AcceptDonationCommandValidator()
        {
            RuleFor(x => x.BloodDonationId)
                .GreaterThan(0)
                .WithMessage("Geçerli bir bağış ID girin.");

           
        }
    }
}
