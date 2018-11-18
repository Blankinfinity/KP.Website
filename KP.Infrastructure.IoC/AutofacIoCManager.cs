using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KP.Infrastructure.IoC.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KP.Infrastructure.IoC
{
    /// <summary>
    /// Class AutofacIoCManager.
    /// </summary>
    /// <seealso cref="IApplicationContainerManager" />
    public class AutofacIoCManager : IApplicationContainerManager
    {
        public virtual IContainer Container { get; set; }

        public void Dispose()
        {
            Container?.Dispose();
        }

        /// <summary>
        /// Populates and get service provider.
        /// </summary>
        /// <param name="descriptors">The descriptors.</param>
        /// <param name="configuration"></param>
        /// <returns>IServiceProvider.</returns>
        public IServiceProvider PopulateAndGetServiceProvider(IEnumerable<ServiceDescriptor> descriptors, IConfiguration configuration)
        {

            var builder = GetContainerBuilder(configuration);
            // Populate the services.
            builder.Populate(descriptors);
            // Build the container.
            Container = builder.Build();

            // Create and return the service provider based on the container.
            return new AutofacServiceProvider(Container);
        }

        /// <summary>
        /// Gets the container builder used to register services.
        /// </summary>
        /// <returns>ContainerBuilder.</returns>
        private ContainerBuilder GetContainerBuilder(IConfiguration configuration)
        {
            // Create the Autofac container builder.
            var builder = new ContainerBuilder();


            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new DbFactoryModule(configuration));
            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new ApplicationModule());

            return builder;
        }
    }
}
