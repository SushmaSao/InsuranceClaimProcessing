﻿using Common.Application.Contracts.Persistence;
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
            services.AddDbContext<CustomerServiceDBContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("CustomerServiceConnectionString")));

            services.AddScoped<IAsyncRepository<Customer>, AsyncRepository<Customer, CustomerServiceDBContext>>();

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<CustomerServiceDBContext>));

            return services;
        }
    }
}