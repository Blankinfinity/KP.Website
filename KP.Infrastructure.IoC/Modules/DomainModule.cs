using Autofac;

namespace KP.Infrastructure.IoC.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("KP.Domain.Contracts")), System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("KP.Domain.Data")))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
