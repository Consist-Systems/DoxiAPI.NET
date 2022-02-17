using Doxi.Domain.Models.RequestResponce;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        public Task<AddSignFlowResponse> AddSignFlowByFileStream(CreateFlowRequestBase createFlowJsonRequest, byte[] file)
        {
            throw new System.NotImplementedException();
        }

        public Task SetFlowAction(SetFlowActionRequest setFlowActionRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task SetSignatures(SetSignaturesExternalRequest setSignaturesExternalRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetFlowStatusResponse> GetFlowStatus(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetFlowMetadataResponse> GetFlowMetadata(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetFlowsStatusResponse[]> GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetAllFlowsResponse> GetAllFlows()
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetAllFlows))
                .GetJsonAsync<GetAllFlowsResponse>();
        }

        public Task<byte[]> GetDocumentWithSigns(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetDocumentWithoutSigns(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetFlowsByFilter(GetFlowsByFilterRequest getFlowsByFilterRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
