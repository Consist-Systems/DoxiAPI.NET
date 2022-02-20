using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        public async Task<byte[]> GetFlowAttachments(string signFlowId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(signFlowId)] = signFlowId,
            };
            var result = await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowAttachments))
                .SetQueryParams(queryParams)
                .GetStreamAsync();
            return result.ToBytes();
        }

        public async Task<byte[]> GetFlowAttachmentField(GetFlowAttachmentFieldRequest getFlowAttachmentFieldRequest)
        {
            var result = await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowAttachmentField))
                .PostJsonAsync(getFlowAttachmentFieldRequest)
                .ReceiveStream();
            return result.ToBytes();
        }

        public async Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(AddAttachmentToFlow))
                .PostJsonAsync(addAttachmentToFlowRequest)
                .ReceiveString();
        }
    }
}
