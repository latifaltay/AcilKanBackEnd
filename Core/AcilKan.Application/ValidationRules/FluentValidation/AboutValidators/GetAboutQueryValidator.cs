using AcilKan.Application.Features.Mediator.Queries.AboutQueries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.ValidationRules.FluentValidation.AboutValidators
{
    public class GetAboutQueryValidator : AbstractValidator<GetAboutQuery>
    {
        public GetAboutQueryValidator()
        {
            
        }
    }
}
