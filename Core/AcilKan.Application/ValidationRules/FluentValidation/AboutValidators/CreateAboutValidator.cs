using AcilKan.Application.Features.Mediator.Commands.AboutCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.ValidationRules.FluentValidation.AboutValidators
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutCommand>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel URL boş olamaz.");
        }
    }
}
