
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

        public async Task<byte[]> GetFlowAttachmentField(string signFlowId, string signerEmail, string elementLabel)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(signFlowId)] = signFlowId,
                [nameof(signerEmail)] = signerEmail,
                [nameof(elementLabel)] = elementLabel,
            };
            var result = await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetFlowAttachmentField))
                .SetQueryParams(queryParams)
                .GetStreamAsync();
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
