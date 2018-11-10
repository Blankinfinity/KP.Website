using KP.Application.Contracts;
using KP.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KP.Presentation.UI.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureCors(this IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
      });
    }

    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
      // We do not initialize any of the properties inside the options because we are just fine with the default values.
      services.Configure<IISOptions>(options =>
      {

      });
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
      services.AddSingleton<ILoggerManager, LoggerManager>();
    }
  }
}
