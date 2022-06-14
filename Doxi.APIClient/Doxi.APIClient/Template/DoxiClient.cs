using Consist.Doxi.Domain.Models;
using Flurl.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient 
    {
        private const string TEMPLATE_BASE = "template";

        public async Task<CreateFlowFromTemplateResponse> CreateFlowFromTemplate(string templateId, CreateFlowFromTemplateRequest createFlowFromTemplateRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(TEMPLATE_BASE)
                .AppendPathSegment(nameof(CreateFlowFromTemplate))
                .AppendPathSegment(templateId)
                .PostJsonAsync(createFlowFromTemplateRequest)
                .ReceiveJson<CreateFlowFromTemplateResponse>();
        }

        public async Task<string> AddTemplate(ExAddTemplateRequest exAddTemplateRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(TEMPLATE_BASE)
                .PostJsonAsync(exAddTemplateRequest)
                .ReceiveString();
        }

        public async Task UpdateTemplate(string templateId, ExUpdateTemplateRequest exUpdateTemplateRequest)
        {
            await GetServiceBaseUrl()
                .AppendPathSegment(TEMPLATE_BASE)
                .AppendPathSegment(templateId)
               .PutJsonAsync(exUpdateTemplateRequest);
        }

        public async Task DeleteUserTemplate(string templateId, DeleteTemplateRequest deleteTemplateRequest)
        {
            await GetServiceBaseUrl()
                .AppendPathSegment(TEMPLATE_BASE)
                .AppendPathSegment(templateId)
                .SendJsonAsync(HttpMethod.Delete, deleteTemplateRequest);
        }

        public async Task<GetExTemplateInfoResponse> GetTemplate(string templateId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(templateId)] = templateId,
            };
            return await GetServiceBaseUrl()
                 .AppendPathSegment(TEMPLATE_BASE)
                 .AppendPathSegment(templateId)
                 .SetQueryParams(queryParams)
                 .GetJsonAsync<GetExTemplateInfoResponse>();
        }
    }
}
