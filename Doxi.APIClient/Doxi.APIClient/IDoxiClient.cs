using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Consist.Doxi.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public interface IDoxiClient
    {
        Task<CreateFlowResponse> AddSignFlowByFileStream(ExCreateFlowRequestBase createFlowJsonRequest, byte[] documentFile);
        Task<byte[]> GetDocumentWithSigns(string signFlowId);
        Task<byte[]> GetDocumentWithoutSigns(string signFlowId);
        Task<GetAllFlowsResponse> GetAllFlows();
        Task<GetFlowsStatusResponse[]> GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest);
        Task SetFlowAction(SetFlowActionRequest setFlowActionRequest);
        Task<byte[]> GetFlowAttachmentField(GetFlowAttachmentFieldRequest getFlowAttachmentFieldRequest);
        Task<GetFlowMetadataResponse> GetFlowMetadata(string signFlowId);
        Task<byte[]> GetFlowAttachments(string signFlowId);
        Task<GetFlowStatusResponse> GetFlowStatus(string signFlowId);
        Task<string> AddNewTemplate(ExAddTemplateRequest exAddTemplateRequest);
        Task UpdateTemplate(ExUpdateTemplateRequest exUpdateTemplateRequest);
        Task<CreateFlowFromTemplateResponse> CreateFlowFromTemplate(CreateFlowFromTemplateRequest createFlowFromTemplateRequest);
        Task<GetExTemplateInfoResponse> GetTemplateInfo(string templateId);
        Task DeleteUserTemplate(DeleteTemplateRequest deleteTemplateRequest);
        Task<GetUserTemplatesResponse[]> GetUserTemplates(ParticipantKey<ParticipantKeyType> userKey);
        Task<List<GetGroupsResponseWithUsersKeys>> GetGroups(ParticipantKey<ParticipantKeyType> userKey);
        Task SetSignatures(ExSetSignFlowRequest exSetSignFlowRequest);
        Task<string> CreateVRMeeting(CreateVRMeetingRequest createVRRoomRequest);
        Task<GetVRMeetingsResponse> GetVRMeetings(GetVRMeetingsRequest getVRMeetingsRequest);
        Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowRequest);
        Task<IEnumerable<string>> GetFlowsByFilter(GetFlowsByFilterRequest getFlowsByFilterRequest);
    }
}
