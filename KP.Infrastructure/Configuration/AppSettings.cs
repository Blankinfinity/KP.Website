using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace KP.Infrastructure.Configuration
{
    public class AppSettings : IAppSetting
    {
        protected IConfiguration Configuration;
        public AppSettings(IHostingEnvironment env)
        {
            var path = env.ContentRootPath;
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", true, true);

                Configuration = builder.Build();
        }

        public string Get(string key)
        {
            return Configuration[key];
        }

        public IConfigurationSection GetSection(string section)
        {
            return Configuration.GetSection(section);
        }
    }
}
