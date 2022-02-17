using Flurl.Http;

namespace Doxi.APIClient
{
    public static class FlurlConfiguration
    {
        public static void ConfigureDomainForDefaultCredentials(string url)
        {
            FlurlHttp.ConfigureClient(url, cli =>
            {
                cli.Settings.HttpClientFactory = new UseDefaultCredentialsClientFactory();
            });
        }

        public static void ConfigureDomainForDefaultCredentials(string url, string username, string password)
        {
            FlurlHttp.ConfigureClient(url, cli =>
            {
                cli.Settings.HttpClientFactory = new UseDefaultCredentialsClientFactory(username,password);
            });
        }
    }
}
