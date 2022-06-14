using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Doxi.APIClient
{
    public partial class DoxiClient : IDoxiClient
    {
        private readonly string _idpUrl;
        private readonly string _serviceUrl;
        private readonly string _companyName;
        private readonly string _userName;
        private readonly string _password;

        public DoxiClient(string idpUrl,string serviceUrl,string companyName, string userName, string password)
        {
            _idpUrl = idpUrl;
            _serviceUrl = serviceUrl;
            _companyName = companyName;
            _userName = userName;
            _password = password;
        }

        private ISerializer _serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        });

        private IFlurlRequest GetServiceBaseUrl() => new Url(_serviceUrl)
           .AppendPathSegment("ex")
           .WithHeader("X-Tenant", _companyName)
           .ConfigureRequest(settings => settings.JsonSerializer = _serializer)
           .AfterCall(HandleErrors)
           .WithAuthentication(_idpUrl, _companyName, _userName, _password);

        private void HandleErrors(FlurlCall flurlCall)
        {
            if (flurlCall?.Response?.StatusCode != 200)
            {
                if (flurlCall.Response.StatusCode == 400)
                    throw new ArgumentException(flurlCall.Response.GetStringAsync().Result);
                else
                    throw new Exception(flurlCall.Response.GetStringAsync().Result);
            }
        }
    }
}
