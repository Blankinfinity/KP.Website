using System.Runtime.CompilerServices;

namespace KP.Infrastructure.Configuration.Options
{
    public class OptionsBase
    {
        protected virtual string SectionName => GetType().Name.Replace("Options", string.Empty);
        protected readonly IAppSetting AppSettings;

        public OptionsBase(IAppSetting appSettings)
        {
            AppSettings = appSettings;
        }

        protected string GetString([CallerMemberName]string subKey = "")
        {
            return AppSettings?.GetSection(SectionName)?[subKey];
        }

        protected int? GetInt([CallerMemberName]string subKey = "")
        {
            if (int.TryParse(AppSettings?.GetSection(SectionName)?[subKey], out int i))
            {
                return i;
            }

            return null;
        }

        protected double? GetDecimal([CallerMemberName]string subKey = "")
        {
            if (double.TryParse(AppSettings?.GetSection(SectionName)?[subKey], out double i))
            {
                return i;
            }

            return null;
        }

        protected bool? GetBoolean([CallerMemberName]string subKey = "")
        {
            if (bool.TryParse(AppSettings?.GetSection(SectionName)?[subKey], out bool i))
            {
                return i;
            }

            return null;
        }
    }
}
