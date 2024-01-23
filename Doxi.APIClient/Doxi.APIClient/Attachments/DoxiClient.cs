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

        public async Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowData)
        {
            return await GetServiceBaseUrl()
            .AppendPathSegment(FLOW_BASE)
            .AppendPathSegment(addAttachmentToFlowData.SignFlowId)
            .AppendPathSegment("attachments")
            .PostMultipartAsync(mp => mp.AddFile("file", new MemoryStream(addAttachmentToFlowData.File.FileBytes), addAttachmentToFlowData.File.Name)
                                         .AddString("addAttachmentToFlowRequest", JsonConvert.SerializeObject(addAttachmentToFlowData)))
             .ReceiveString();
        }

        public async Task<AddAttachmentAsBase64ToFlowResponse> AddAttachmentAsBase64ToFlow(string signFlowId, AddAttachmentBase64ToFlowRequest addAttachmentToFlowRequest)
        {
            return await GetServiceBaseUrl()
            .AppendPathSegment(FLOW_BASE)
            .AppendPathSegment(signFlowId)
            .AppendPathSegment("attachments/base64")
            .PostJsonAsync(addAttachmentToFlowRequest)
            .ReceiveJson<AddAttachmentAsBase64ToFlowResponse>();
        }
    }
}
