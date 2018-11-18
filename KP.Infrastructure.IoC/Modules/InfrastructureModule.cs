using Autofac;
using KP.Infrastructure.Configuration;
using KP.Infrastructure.Configuration.Options;

namespace KP.Infrastructure.IoC.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Configuration
            builder.RegisterType<AppSettings>()
                .As<IAppSetting>()
                .SingleInstance();

            builder.RegisterType<ConnectionStringsOptions>()
                .SingleInstance();
            builder.RegisterType<LoggingOptions>()
                .SingleInstance();
        }
    }
}
