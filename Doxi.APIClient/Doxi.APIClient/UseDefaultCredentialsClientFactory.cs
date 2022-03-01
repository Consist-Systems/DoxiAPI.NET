using Flurl.Http.Configuration;
using System.Net;
using System.Net.Http;

namespace Doxi.APIClient
{
    public class UseDefaultCredentialsClientFactory : DefaultHttpClientFactory
    {
        private readonly string _username;
        private readonly string _password;
        private bool _acceptAnyServerCertificateValidator;

        public UseDefaultCredentialsClientFactory(bool acceptAnyServerCertificateValidator)
        {
            _acceptAnyServerCertificateValidator = acceptAnyServerCertificateValidator;
        }
        
        public UseDefaultCredentialsClientFactory(string username, string password, bool acceptAnyServerCertificateValidator)
        {
            _username = username;
            _password = password;
            _acceptAnyServerCertificateValidator = acceptAnyServerCertificateValidator;
        }

        public override HttpMessageHandler CreateMessageHandler()
        {
            var httpClientHandler = new HttpClientHandler { 
                UseDefaultCredentials = true,
            };
            if (!string.IsNullOrWhiteSpace(_username))
                httpClientHandler.Credentials = new NetworkCredential(_username, _password);

            if (_acceptAnyServerCertificateValidator)
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            return httpClientHandler;
        }

    }
}
