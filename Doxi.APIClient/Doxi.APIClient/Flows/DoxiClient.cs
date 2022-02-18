
using Flurl.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        public async Task<AddSignFlowResponse> AddSignFlowByFileStream(CreateFlowRequestBase createFlowJsonRequest, byte[] documentFile)
        {
            using (var stream = new MemoryStream(documentFile))
            {
                return await GetServiceBaseUrl()
                    .AppendPathSegment(nameof(AddSignFlowByFileStream))
                    .PostMultipartAsync(mp => mp
                    .AddFile("file", stream, createFlowJsonRequest.DocumentFileName)
                    .AddJson("createFlowJsonRequest", createFlowJsonRequest))
                    .ReceiveJson<AddSignFlowResponse>();
                }
        }

        public async Task SetFlowAction(SetFlowActionRequest setFlowActionRequest)
        {
             await GetServiceBaseUrl()
                .AppendPathSegment(nameof(SetFlowAction))
                .PostJsonAsync(setFlowActionRequest);
        }

        public async Task SetSignatures(SetSignaturesExternalRequest setSignaturesExternalRequest)
        {
             await GetServiceBaseUrl()
                .AppendPathSegment(nameof(SetSignatures))
                .PostJsonAsync(setSignaturesExternalRequest);
        }

        public async Task<GetFlowStatusResponse> GetFlowStatus(string signFlowId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(signFlowId)] = signFlowId,
            };
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowStatus))
                .SetQueryParams(queryParams)
                .GetJsonAsync<GetFlowStatusResponse>();
        }

        public async Task<GetFlowMetadataResponse> GetFlowMetadata(string signFlowId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(signFlowId)] = signFlowId,
            };
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowMetadata))
                .SetQueryParams(queryParams)
                .GetJsonAsync<GetFlowMetadataResponse>();
        }

        public async Task<GetFlowsStatusResponse[]> GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowsStatus))
                .PostJsonAsync(getFlowsStatusRequest)
                .ReceiveJson<GetFlowsStatusResponse[]>();
        }

        public async Task<GetAllFlowsResponse> GetAllFlows()
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetAllFlows))
                .GetJsonAsync<GetAllFlowsResponse>();
        }

        public async Task<byte[]> GetDocumentWithSigns(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<byte[]> GetDocumentWithoutSigns(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetFlowsByFilter(GetFlowsByFilterRequest getFlowsByFilterRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowsByFilter))
                .PostJsonAsync(getFlowsByFilterRequest)
                .ReceiveJson<IEnumerable<string>>();
        }
    }
}
