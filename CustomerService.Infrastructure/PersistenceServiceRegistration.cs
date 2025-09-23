using Common.Application.Contracts.Persistence;
using Common.Application.Contracts.UserContract;
using Common.Infrastructure.UserService;
using Common.Persistence.Repositories;
using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerServiceDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("CustomerServiceConnectionString")));

            services.AddScoped<IAsyncCommandRepository<CustomerProfile>, AsyncCommandRepository<CustomerProfile, CustomerServiceDBContext>>();
            services.AddScoped<IAsyncQueryRepository<CustomerProfile>, AsyncQueryRepository<CustomerProfile, CustomerServiceDBContext>>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<CustomerServiceDBContext>));

            return services;
        }
    }
}
