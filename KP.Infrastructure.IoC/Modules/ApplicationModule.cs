using Autofac;
using KP.Infrastructure.Logger;

namespace KP.Infrastructure.IoC.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("KP.Application.Contracts")), System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("KP.Application.Services")))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<LogManager>()
                .As<ILogManager>()
                .SingleInstance();
        }
    }
}
