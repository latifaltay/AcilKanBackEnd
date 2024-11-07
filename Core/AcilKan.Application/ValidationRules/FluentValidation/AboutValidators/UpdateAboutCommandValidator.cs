using AcilKan.Application.Constants;
using AcilKan.Application.Features.Mediator.Commands.AboutCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.ValidationRules.FluentValidation.AboutValidators
{
    public class UpdateAboutCommandValidator : AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage(Messages.AboutIdGreaterThanZero);
            RuleFor(x => x.Title).NotEmpty().WithMessage(Messages.AboutTitleNotEmpty);
            RuleFor(x => x.Title).MaximumLength(100).WithMessage(Messages.AboutTitleMaxLength);
            RuleFor(x => x.Description).NotEmpty().WithMessage(Messages.AboutDescriptionNotEmpty);
            RuleFor(x => x.Description).MaximumLength(500).WithMessage(Messages.AboutDescriptionMaxLength);
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage(Messages.AboutImageUrlNotEmpty);
            RuleFor(x => x.ImageUrl).Must(BeAValidUrl).WithMessage(Messages.AboutImageUrlInvalid);
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
