using System.Collections.Generic;

namespace Doxi.APIClient.Tests
{
    internal class GetFlowsByFilterRequest : Consist.Doxi.Domain.Models.ExternalAPI.GetFlowsByFilterRequest
    {
        public KeyValuePair<string, string>[] CustomFields { get; set; }
        public int SignatureFlowStatus { get; set; }
    }
}