﻿using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
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

        public async Task<string> AddAttachmentToFlow(string signFlowId, AddAttachmentToFlowRequest addAttachmentToFlowRequest)
        {
            return await GetServiceBaseUrl()
            .AppendPathSegment(FLOW_BASE)
            .AppendPathSegment(signFlowId)
            .AppendPathSegment("attachments")
            .PostMultipartAsync(mp => mp.AddFile("file", new MemoryStream(addAttachmentToFlowRequest.FileByte), addAttachmentToFlowRequest.FileName)
                                         .AddString("addAttachmentToFlowRequest", JsonConvert.SerializeObject(addAttachmentToFlowRequest)))
             .ReceiveString();
        }
    }
}
