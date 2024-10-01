using IdentityService.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, SecurePasswordHelper>();
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
