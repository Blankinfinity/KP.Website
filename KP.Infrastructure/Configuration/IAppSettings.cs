using Microsoft.Extensions.Configuration;

namespace KP.Infrastructure.Configuration
{
    public interface IAppSetting
    {
        string Get(string key);
        IConfigurationSection GetSection(string section);
    }
}
