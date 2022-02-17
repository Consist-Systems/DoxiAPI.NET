using Flurl.Http.Configuration;
using System.Net;
using System.Net.Http;

namespace Doxi.APIClient
{
    public class UseDefaultCredentialsClientFactory : DefaultHttpClientFactory
    {
        private readonly string _username;
        private readonly string _password;

        public UseDefaultCredentialsClientFactory()
        {
        }
        
        public UseDefaultCredentialsClientFactory(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler { UseDefaultCredentials = true };
        }

        public override HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            if(!string.IsNullOrWhiteSpace(_username))
                ((HttpClientHandler)handler).Credentials = new NetworkCredential(_username, _password);
            return base.CreateHttpClient(handler);
        }
    }
}
