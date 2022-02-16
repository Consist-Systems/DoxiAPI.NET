using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using System.Collections.Generic;
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

        public Task<CreateFlowResponse> AddSignFlowByFileStream(byte[] file, ExCreateFlowRequestBase createFlowJsonRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<CreateFlowResponse> CreateFlow(CreateFlowFromFileRequest fileWithSenderMail)
        {
            throw new System.NotImplementedException();
        }

        public Task<CreateFlowResponse> CreateFlowFromFile(CreateFlowFromFileRequest fileWithSenderMail)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetDocumentWithoutSigns(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetDocumentWithSigns(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetFlowMetadataResponse> GetFlowMetadata(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetFlowsByFilter(GetFlowsByFilterRequest getFlowsByFilterRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetFlowsStatusResponse[]> GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetFlowStatusResponse> GetFlowStatus(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task SetFlowAction(SetFlowActionRequest setFlowActionRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task SetSignatures(ExSetSignFlowRequest exSetSignFlowRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
