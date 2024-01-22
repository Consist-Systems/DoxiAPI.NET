using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
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
                .AppendPathSegment(FLOW_BASE)
                .AppendPathSegment(signFlowId)
                .AppendPathSegment("attachments")
                .SetQueryParams(queryParams)
                .GetStreamAsync();
            return result.ToBytes();
        }

        public async Task<byte[]> GetFlowAttachmentField(string signFlowId, GetFlowAttachmentFieldRequest getFlowAttachmentFieldRequest)
        {
            var result = await GetServiceBaseUrl()
                .AppendPathSegment(FLOW_BASE)
                .AppendPathSegment(signFlowId)
                .AppendPathSegment("AttachmentField")
                .PostJsonAsync(getFlowAttachmentFieldRequest)
                .ReceiveStream();
            return result.ToBytes();
        }

        public async Task<string> AddAttachmentToFlow(AddAttachmentToFlowData addAttachmentToFlowData)
        {
            return await GetServiceBaseUrl()
            .AppendPathSegment(FLOW_BASE)
            .AppendPathSegment(addAttachmentToFlowData.SignFlowId)
            .AppendPathSegment("attachments")
            .PostMultipartAsync(mp => mp.AddFile("file", new MemoryStream(addAttachmentToFlowData.FileByte), addAttachmentToFlowData.FileName)
                                         .AddString("addAttachmentToFlowRequest", JsonConvert.SerializeObject(addAttachmentToFlowData)))
             .ReceiveString();
        }
    }
}
