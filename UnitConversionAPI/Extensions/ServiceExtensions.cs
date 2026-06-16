
using UnitConversionAPI.Services;

namespace UnitConversionAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitConversionService, UnitConversionService>();
            return services;
        }
    }
}
