using Doxi.Domain.Models.RequestResponce;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public interface IDoxiClient
    {
        Task<AddSignFlowResponse> AddSignFlowByFileStream(CreateFlowRequestBase createFlowJsonRequest,
                                                                       byte[] file);
        Task SetFlowAction(SetFlowActionRequest setFlowActionRequest);
        Task SetSignatures(SetSignaturesExternalRequest setSignaturesExternalRequest);
        Task<CreateFlowFromTemplateResponce> CreateFlowFromTemplate(CreateFlowFromTemplateRequest createFlowFromTemplateRequest);
        GetFlowStatusResponse GetFlowStatus(string signFlowId);
        GetFlowMetadataResponse GetFlowMetadata(string signFlowId);
        GetFlowsStatusResponse[] GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest);
        GetAllFlowsResponse GetAllFlows();
        byte[] GetDocumentWithSigns(string signFlowId);
        byte[] GetDocumentWithoutSigns(string signFlowId);
        GetGroupsResponse GetGroups(string userName);
        Task<byte[]> GetFlowAttachments(string signFlowId);
        Task<byte[]> GetFlowAttachmentField(string signFlowId, string signerEmail, string elementLabel);
        GetUserTemplatesResponse GetUserTemplates(string userName);
        Task<string> AddNewTemplate(ExAddTemplateRequest exAddTemplateRequest);
        Task UpdateTemplate(ExUpdateTemplateRequest exUpdateTemplateRequest);
        Task DeleteTemplate(string userName, string templateId);
        Task<GetExTemplateInfoResponse> GetTemplateInfo(string templateId);
        string Encrypt(string text);
        Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowRequest);
        IEnumerable<string> GetFlowsByFilter(GetFlowsByFilterRequest getFlowsByFilterRequest);
    }
}
