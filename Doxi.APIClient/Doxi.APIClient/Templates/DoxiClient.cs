using Doxi.Domain.Models.RequestResponce;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        public Task<CreateFlowFromTemplateResponce> CreateFlowFromTemplate(CreateFlowFromTemplateRequest createFlowFromTemplateRequest)
        {
            throw new System.NotImplementedException();
        }
        public Task<GetUserTemplatesResponse> GetUserTemplates(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> AddNewTemplate(ExAddTemplateRequest exAddTemplateRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateTemplate(ExUpdateTemplateRequest exUpdateTemplateRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteTemplate(string userName, string templateId)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetExTemplateInfoResponse> GetTemplateInfo(string templateId)
        {
            throw new System.NotImplementedException();
        }

    }
}
