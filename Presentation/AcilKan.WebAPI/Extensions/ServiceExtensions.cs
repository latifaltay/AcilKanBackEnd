using AcilKan.Application.Interfaces;
using AcilKan.Application.ValidationRules.FluentValidation.AboutValidators;
using AcilKan.Persistence.Context;
using AcilKan.Persistence.Repositories;
using AcilKan.Persistence.Services;
using AcilKan.Persistence.Utilities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcilKan.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtentions(this IServiceCollection Services)
        {
            //Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // MediatR Registration
            Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // DbContext Registration
            Services.AddScoped<AcilKanContext>();

            // Repository Registration
            Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            Services.AddScoped<ICityService, CityRepository>();
            Services.AddScoped<IDistrictService, DistrictRepository>();
            Services.AddScoped<IBloodRequestService, BloodRequestRepository>();

            // Validation Pipeline Registration
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Kullanıcı id'sini almak için kullandım
            Services.AddHttpContextAccessor();




        }
    }
}
