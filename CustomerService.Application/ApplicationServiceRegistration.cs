using CustomerService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddScoped<ICustomerProfileService, CustomerProfileService>();
            return services;
        }
    }
}
