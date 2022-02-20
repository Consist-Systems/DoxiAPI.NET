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
        public async Task<GetAllFlowsResponse> GetAllFlows()
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetAllFlows))
                .GetJsonAsync<GetAllFlowsResponse>()
                .ConfigureAwait(false);
        }

        public async Task<CreateFlowResponse> AddSignFlowByFileStream(ExCreateFlowRequestBase createFlowJsonRequest, byte[] documentFile)
        {
            using (var stream = new MemoryStream(documentFile))
            {
                return await GetServiceBaseUrl()
                    .AppendPathSegment(nameof(AddSignFlowByFileStream))
                    .PostMultipartAsync(mp => mp
                    .AddFile("file", stream, createFlowJsonRequest.DocumentFileName)
                    .AddJson("createFlowJsonRequest", createFlowJsonRequest))
                    .ReceiveJson<CreateFlowResponse>();
            }
        }



        public async Task<byte[]> GetDocumentWithSigns(string signFlowId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(signFlowId)] = signFlowId,
            };
            var result = await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetDocumentWithSigns))
                .SetQueryParams(queryParams)
                .GetStreamAsync();
            return result.ToBytes();
        }

        public async Task<byte[]> GetDocumentWithoutSigns(string signFlowId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(signFlowId)] = signFlowId,
            };
            var result = await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetDocumentWithoutSigns))
                .SetQueryParams(queryParams)
                .GetStreamAsync();
            return result.ToBytes();
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

        public async Task<IEnumerable<string>> GetFlowsByFilter(GetFlowsByFilterRequest getFlowsByFilterRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowsByFilter))
                .PostJsonAsync(getFlowsByFilterRequest)
                .ReceiveJson<IEnumerable<string>>();
        }

        public async Task<GetFlowsStatusResponse[]> GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowsStatus))
                .PostJsonAsync(getFlowsStatusRequest)
                .ReceiveJson<GetFlowsStatusResponse[]>();
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

        public async Task SetFlowAction(SetFlowActionRequest setFlowActionRequest)
        {
            await GetServiceBaseUrl()
               .AppendPathSegment(nameof(SetFlowAction))
               .PostJsonAsync(setFlowActionRequest);
        }

        public async Task SetSignatures(ExSetSignFlowRequest exSetSignFlowRequest)
        {
            await GetServiceBaseUrl()
               .AppendPathSegment(nameof(SetSignatures))
               .PostJsonAsync(exSetSignFlowRequest);
        }
    }
}
