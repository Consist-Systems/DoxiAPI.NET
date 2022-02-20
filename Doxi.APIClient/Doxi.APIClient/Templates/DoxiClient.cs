using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient 
    {
        public async Task<CreateFlowFromTemplateResponse> CreateFlowFromTemplate(CreateFlowFromTemplateRequest createFlowFromTemplateRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(CreateFlowFromTemplate))
                .PostJsonAsync(createFlowFromTemplateRequest)
                .ReceiveJson<CreateFlowFromTemplateResponse>();
        }
        public async Task<GetUserTemplatesResponse[]> GetUserTemplates(ParticipantKey<ParticipantKeyType> userKey)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetUserTemplates))
                .PostJsonAsync(userKey)
                .ReceiveJson<GetUserTemplatesResponse[]>();
        }

        public async Task<string> AddNewTemplate(ExAddTemplateRequest exAddTemplateRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(AddNewTemplate))
                .PostJsonAsync(exAddTemplateRequest)
                .ReceiveString();
        }

        public async Task UpdateTemplate(ExUpdateTemplateRequest exUpdateTemplateRequest)
        {
            await GetServiceBaseUrl()
               .AppendPathSegment(nameof(UpdateTemplate))
               .PostJsonAsync(exUpdateTemplateRequest);
        }

        public async Task DeleteUserTemplate(DeleteTemplateRequest deleteTemplateRequest)
        {
            await GetServiceBaseUrl()
                .AppendPathSegment(nameof(DeleteUserTemplate))
                .PostJsonAsync(deleteTemplateRequest);
        }

        public async Task<GetExTemplateInfoResponse> GetTemplateInfo(string templateId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(templateId)] = templateId,
            };
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetTemplateInfo))
                .SetQueryParams(queryParams)
                .GetJsonAsync<GetExTemplateInfoResponse>();
        }
    }
}
