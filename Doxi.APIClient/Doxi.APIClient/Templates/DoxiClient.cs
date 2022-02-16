using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient 
    {
        public Task<CreateFlowFromTemplateResponse> CreateFlowFromTemplate(CreateFlowFromTemplateRequest createFlowFromTemplateRequest)
        {
            throw new System.NotImplementedException();
        }


        public Task<string> AddNewTemplate(ExAddTemplateRequest exAddTemplateRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUserTemplate(DeleteTemplateRequest deleteTemplateRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetExTemplateInfoResponse> GetTemplateInfo(string templateId)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetUserTemplatesResponse[]> GetUserTemplates(ParticipantKey<ParticipantKeyType> userKey)
        {
            throw new System.NotImplementedException();
        }
        public Task UpdateTemplate(ExUpdateTemplateRequest exUpdateTemplateRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
