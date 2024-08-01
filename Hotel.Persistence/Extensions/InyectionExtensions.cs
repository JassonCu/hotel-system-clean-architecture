using Hotel.Interface.Interfaces;
using Hotel.Persistence.Context;
using Hotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Persistence.Extensions
{
    public static class InyectionExtensions
    {
        public static IServiceCollection AddInyectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDBContext>();
            services.AddScoped<IEmployeesRepository, EmployeesRepositories>();

            return services;
        }
    }
}
