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
              options.UseSqlServer(configuration.GetConnectionString("EInsuranceIdentityConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<Users>), typeof(AsyncRepository<Users, IdentityServiceDBContext>));
            services.AddScoped(typeof(IAsyncRepository<UserRoles>), typeof(AsyncRepository<UserRoles, IdentityServiceDBContext>));


            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<IdentityServiceDBContext>));

            return services;
        }
    }
}
