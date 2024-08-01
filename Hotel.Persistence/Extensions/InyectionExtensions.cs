using Hotel.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Persistence.Extensions
{
    public static class InyectionExtensions
    {
        public static IServiceCollection AddInyectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDBContext>();

            return services;
        }
    }

}
