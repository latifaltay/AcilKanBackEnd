using AcilKan.Application.Features.Mediator.Commands.AboutCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Application.ValidationRules.FluentValidation.AboutValidators;
using AcilKan.Persistence.Context;
using AcilKan.Persistence.Repositories;
using FluentValidation;
using MediatR;

namespace AcilKan.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtentions(this IServiceCollection Services)
        {
            //Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            Services.AddScoped<AcilKanContext>();
            
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            Services.AddTransient<IValidator<CreateAboutCommand>, CreateAboutValidator>();


            Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



        }
    }
}
