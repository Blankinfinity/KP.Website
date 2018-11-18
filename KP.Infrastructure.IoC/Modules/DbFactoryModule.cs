using Autofac;
using KP.Infrastructure.Connections;
using Microsoft.Extensions.Configuration;

namespace KP.Infrastructure.IoC.Modules
{
    public class DbFactoryModule : Module
    {

        private readonly IConfiguration _configuration;

        public DbFactoryModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Register Connection class and expose IConnection 
            // by passing in the Database connection information
            builder.RegisterType<ConnectionFactory>() // concrete type
                .As<IConnectionFactory>() // abstraction
                .WithParameter("connectionString", _configuration.GetConnectionString("ProdConnection"))
                .InstancePerLifetimeScope();
        }
    }
}
