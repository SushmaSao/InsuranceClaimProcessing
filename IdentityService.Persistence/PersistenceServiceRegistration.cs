using Common.Application.Contracts.Persistence;
using Common.Persistence.Repositories;
using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityServiceDBContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("EInsuranceIdentityConnectionString")));

            services.AddScoped(typeof(IAsyncCommandRepository<Users>), typeof(AsyncCommandRepository<Users, IdentityServiceDBContext>));
            services.AddScoped(typeof(IAsyncCommandRepository<UserRoles>), typeof(AsyncCommandRepository<UserRoles, IdentityServiceDBContext>));


            services.AddScoped(typeof(IAsyncQueryRepository<Users>), typeof(AsyncQueryRepository<Users, IdentityServiceDBContext>));
            services.AddScoped(typeof(IAsyncQueryRepository<UserRoles>), typeof(AsyncQueryRepository<UserRoles, IdentityServiceDBContext>));


            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<IdentityServiceDBContext>));

            return services;
        }
    }
}
