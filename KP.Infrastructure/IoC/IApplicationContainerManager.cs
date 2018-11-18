using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KP.Infrastructure.IoC
{
    public interface IApplicationContainerManager : IDisposable
    {
        IServiceProvider PopulateAndGetServiceProvider(IEnumerable<ServiceDescriptor> descriptors, IConfiguration configuration);
    }
}
