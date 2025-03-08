using AcilKan.Application.Interfaces;
using AcilKan.Application.ValidationRules.Behaviors;
using AcilKan.Application.ValidationRules.FluentValidation.Validators.AppUserValidators;
using AcilKan.Persistence.Context;
using AcilKan.Persistence.Repositories;
using AcilKan.Persistence.Services;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace AcilKan.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtentions(this IServiceCollection Services)
        {
            //Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // MediatR Registration
            Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // FluentValidation - Application Katmanındaki Validatorları Tara!
            Services.AddValidatorsFromAssembly(typeof(CreateAppUserCommandValidator).Assembly);

            // Validation Pipeline Registration
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            // DbContext Registration
            Services.AddScoped<AcilKanContext>();

            // Repository Registration
            Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            Services.AddScoped<ICityService, CityRepository>();
            Services.AddScoped<IDistrictService, DistrictRepository>();
            Services.AddScoped<IBloodRequestService, BloodRequestRepository>();
            Services.AddScoped<IBloodDonationService, BloodDonationRepository>();
            Services.AddScoped<IAppUserService, AppUserRepository>();
            Services.AddScoped<IBloodDonationApproveService, BloodDonationApproveRepository>();
            Services.AddScoped<IChatService, ChatRepository>();
            Services.AddTransient<IUserProfileService, UserProfileRepository>();
            Services.AddScoped<ITCIdentityVerificationService, TCIdentityVerificationService>();
            Services.AddSingleton<IDateTimeService, DateTimeService>();


            // Validation Pipeline Registration
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Kullanıcı id'sini almak için kullandım
            Services.AddHttpContextAccessor();

        }
    }
}
