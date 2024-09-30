using ClaimProcessingService.Application.Contracts.Persistence;
using ClaimProcessingService.Persistence.Repositories;
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
              options.UseSqlServer(configuration.GetConnectionString("ClaimProcessingServiceConnectionString")));


            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
