namespace KP.Infrastructure.Configuration.Options
{
    public class ConnectionStringsOptions : OptionsBase
    {
        public ConnectionStringsOptions(IAppSetting appSettings) : base(appSettings) {}

        public string ProdConnection => GetString();
        public string PreProdConnection => GetString();
    }
}
