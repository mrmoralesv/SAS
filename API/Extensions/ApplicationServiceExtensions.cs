using Core.Interfaces;

namespace API.Extensions;
public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", Builder =>
            Builder
            .AllowAnyOrigin() //WithOrigins(http://midominio.com)
            .AllowAnyMethod() //WithMethods("GET","POST")
            .AllowAnyOrigin() //WithHeaders("accept","content-type")
            );
        });

    public static void AddAplicacionServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
