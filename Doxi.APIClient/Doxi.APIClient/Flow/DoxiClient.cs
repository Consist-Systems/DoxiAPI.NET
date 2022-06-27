using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        private const string FLOW_BASE = "flow";

        public async Task<GetAllFlowsResponse> GetAllFlows()
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(FLOW_BASE)
                .GetJsonAsync<GetAllFlowsResponse>()
                .ConfigureAwait(false);
        }

        public async Task<CreateFlowResponse> AddSignFlow(ExCreateFlowRequestBase createFlowJsonRequest, byte[] documentFile)
        {
            using (var stream = new MemoryStream(documentFile))
            {
                return await GetServiceBaseUrl()
                    .AppendPathSegment(FLOW_BASE)
                    .PostMultipartAsync(mp => mp
                    .AddFile("file", stream, createFlowJsonRequest.DocumentFileName)
                    .AddJson("createFlowJsonRequest", createFlowJsonRequest))
                    .ReceiveJson<CreateFlowResponse>();
            }
        }



        public async Task<byte[]> GetDocument(string signFlowId, bool withSigns = true)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(signFlowId)] = signFlowId,
            };
            var result = await GetServiceBaseUrl()
                .AppendPathSegment(FLOW_BASE)
                .AppendPathSegment($"{signFlowId}/Document/{withSigns}")
                .SetQueryParams(queryParams)
                .GetStreamAsync();
            return result.ToBytes();
        }


        public async Task<GetFlowMetadataResponse> GetFlow(string signFlowId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(signFlowId)] = signFlowId,
            };
            return await GetServiceBaseUrl()
                .AppendPathSegment(FLOW_BASE)
                .AppendPathSegment(signFlowId)
                .SetQueryParams(queryParams)
                .GetJsonAsync<GetFlowMetadataResponse>();
        }

        public async Task<IEnumerable<string>> SearchFlow(GetFlowsByFilterRequest getFlowsByFilterRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(FLOW_BASE)
                .AppendPathSegment("search")
                .PostJsonAsync(getFlowsByFilterRequest)
                .ReceiveJson<IEnumerable<string>>();
        }

        public async Task<GetFlowsStatusResponse[]> GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(FLOW_BASE)
                .AppendPathSegment("status")
                .PostJsonAsync(getFlowsStatusRequest)
                .ReceiveJson<GetFlowsStatusResponse[]>();
        }

        public async Task<GetFlowStatusResponse> GetFlowStatus(string signFlowId)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(FLOW_BASE)
                .AppendPathSegment($"{signFlowId}/status")
                .GetJsonAsync<GetFlowStatusResponse>();
        }

        public async Task SetFlowAction(string signFlowId,SetFlowActionRequest setFlowActionRequest)
        {
            await GetServiceBaseUrl()
                .AppendPathSegment(FLOW_BASE)
               .AppendPathSegment($"{signFlowId}/action")
               .PostJsonAsync(setFlowActionRequest);
        }

        public async Task SetSignatures(string signFlowId, ExSetSignFlowRequest exSetSignFlowRequest)
        {
            await GetServiceBaseUrl()
               .AppendPathSegment(FLOW_BASE)
               .AppendPathSegment($"{signFlowId}/SetSignatures")
               .PostJsonAsync(exSetSignFlowRequest);
        }
    }
}
