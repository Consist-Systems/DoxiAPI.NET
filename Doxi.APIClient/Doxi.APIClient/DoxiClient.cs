using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;

namespace Doxi.APIClient
{
    public partial class DoxiClient : IDoxiClient
    {
        private readonly string _serviceUrl;
        private readonly string _username;
        private readonly string _password;

        public DoxiClient(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
            FlurlConfiguration.ConfigureDomainForDefaultCredentials(serviceUrl);
        }

        public DoxiClient(string serviceUrl,string username,string password)
        {
            _serviceUrl = serviceUrl;
            _username = username;
            _password = password;
            FlurlConfiguration.ConfigureDomainForDefaultCredentials(serviceUrl, username, password);
        }

        private ISerializer _serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        });

        private IFlurlRequest GetServiceBaseUrl()
        {
            return new Url(_serviceUrl)
               .AppendPathSegment("/ExternalDoxiAPI")
               .ConfigureRequest(settings => settings.JsonSerializer = _serializer)
               .AfterCall(HandleErrors);
        }


        private void HandleErrors(FlurlCall flurlCall)
        {
            if(flurlCall?.Response?.StatusCode != 200)
            {
                if(flurlCall.Response.StatusCode == 400)
                    throw new ArgumentException(flurlCall.Response.GetStringAsync().Result);
                else
                    throw new Exception(flurlCall.Response.GetStringAsync().Result);
            }
            
        }
    }
}
