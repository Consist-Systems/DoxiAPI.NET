
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public interface IDoxiClient
    {
        Task<AddSignFlowResponse> AddSignFlowByFileStream(CreateFlowRequestBase createFlowJsonRequest,byte[] file);
        Task SetFlowAction(SetFlowActionRequest setFlowActionRequest);
        Task SetSignatures(SetSignaturesExternalRequest setSignaturesExternalRequest);
        Task<CreateFlowFromTemplateResponce> CreateFlowFromTemplate(CreateFlowFromTemplateRequest createFlowFromTemplateRequest);
        Task<GetFlowStatusResponse> GetFlowStatus(string signFlowId);
        Task<GetFlowMetadataResponse> GetFlowMetadata(string signFlowId);
        Task<GetFlowsStatusResponse[]> GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest);
        Task<GetAllFlowsResponse> GetAllFlows();
        Task<byte[]> GetDocumentWithSigns(string signFlowId);
        Task<byte[]> GetDocumentWithoutSigns(string signFlowId);
        Task<GetGroupsResponse> GetGroups(string userName);
        Task<byte[]> GetFlowAttachments(string signFlowId);
        Task<byte[]> GetFlowAttachmentField(string signFlowId, string signerEmail, string elementLabel);
        Task<GetUserTemplatesResponse> GetUserTemplates(string userName);
        Task<string> AddNewTemplate(ExAddTemplateRequest exAddTemplateRequest);
        Task UpdateTemplate(ExUpdateTemplateRequest exUpdateTemplateRequest);
        Task DeleteTemplate(string userName, string templateId);
        Task<GetExTemplateInfoResponse> GetTemplateInfo(string templateId);
        Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowRequest);
        Task<IEnumerable<string>> GetFlowsByFilter(GetFlowsByFilterRequest getFlowsByFilterRequest);
    }
}
