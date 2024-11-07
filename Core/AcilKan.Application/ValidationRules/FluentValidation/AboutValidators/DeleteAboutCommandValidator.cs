using FluentValidation;
using AcilKan.Application.Features.Mediator.Commands.AboutCommands;
using AcilKan.Application.Constants;
using AcilKan.Application.Interfaces; 
using System.Threading.Tasks;
using AcilKan.Domain.Entities;


namespace AcilKan.Application.ValidationRules.FluentValidation.AboutValidators 
{
    public class DeleteAboutCommandValidator : AbstractValidator<DeleteAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public DeleteAboutCommandValidator(IRepository<About> repository)
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
