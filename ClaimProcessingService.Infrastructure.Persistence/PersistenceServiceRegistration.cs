using ClaimProcessingService.Domain.Entities;
using Common.Application.Contracts.Persistence;
using Common.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimProcessingService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClaimProcessingServiceDBContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("ClaimProcessingServiceConnectionString")));

            services.AddScoped<IAsyncRepository<Claim>, AsyncRepository<Claim, ClaimProcessingServiceDBContext>>();

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<ClaimProcessingServiceDBContext>));

            return services;
        }
    }
}
