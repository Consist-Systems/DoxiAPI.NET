
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        public async Task<CreateFlowFromTemplateResponce> CreateFlowFromTemplate(CreateFlowFromTemplateRequest createFlowFromTemplateRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(CreateFlowFromTemplate))
                .PostJsonAsync(createFlowFromTemplateRequest)
                .ReceiveJson<CreateFlowFromTemplateResponce>();
        }
        public async Task<GetUserTemplatesResponse> GetUserTemplates(string userName)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(userName)] = userName,
            };
            return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetUserTemplates))
                .SetQueryParams(queryParams)
                .GetJsonAsync<GetUserTemplatesResponse>();
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

        public async Task DeleteTemplate(string userName, string templateId)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(userName)] = userName,
                [nameof(templateId)] = templateId,
            };
            await GetServiceBaseUrl()
                .AppendPathSegment(nameof(DeleteTemplate))
                .SetQueryParams(queryParams)
                .PostAsync();
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
