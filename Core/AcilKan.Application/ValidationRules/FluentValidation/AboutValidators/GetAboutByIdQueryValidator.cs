using AcilKan.Application.Constants;
using AcilKan.Application.Features.Mediator.Queries.AboutQueries;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.ValidationRules.FluentValidation.AboutValidators
{
    public class GetAboutByIdQueryValidator : AbstractValidator<GetAboutByIdQuery>
    {
        private readonly IRepository<About> _repository;
        public GetAboutByIdQueryValidator(IRepository<About> repository)
        {
            _repository = repository;

            RuleFor(x => x.Id).GreaterThan(0).WithMessage(Messages.AboutIdGreaterThanZero);
            RuleFor(x => x.Id).MustAsync(BeExistingId).WithMessage(Messages.AboutIdNotFound);
        }

        private async Task<bool> BeExistingId(int id, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(id);
            return about != null;
        }
    }
}
