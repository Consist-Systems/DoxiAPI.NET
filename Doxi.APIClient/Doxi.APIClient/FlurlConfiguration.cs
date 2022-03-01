using Flurl.Http;

namespace Doxi.APIClient
{
    public static class FlurlConfiguration
    {
        public static void ConfigureDomainForDefaultCredentials(string url, bool acceptAnyServerCertificateValidator)
        {
            FlurlHttp.ConfigureClient(url, cli =>
            {
                cli.Settings.HttpClientFactory = new UseDefaultCredentialsClientFactory(acceptAnyServerCertificateValidator);
            });
        }

        public static void ConfigureDomainForDefaultCredentials(string url, string username, string password, bool acceptAnyServerCertificateValidator)
        {
            FlurlHttp.ConfigureClient(url, cli =>
            {
                cli.Settings.HttpClientFactory = new UseDefaultCredentialsClientFactory(username,password, acceptAnyServerCertificateValidator);
                cli.AllowHttpStatus("400");

            });
        }

    }
}
