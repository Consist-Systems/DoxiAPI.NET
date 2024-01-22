using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Consist.Doxi.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public interface IDoxiClient
    {
        Task<CreateFlowResponse> AddSignFlow(ExCreateFlowRequestBase createFlowJsonRequest, byte[] documentFile);
        Task<byte[]> GetDocument(string signFlowId, bool withSigns = true);
        Task<GetAllFlowsResponse> GetAllFlows();
        Task<GetFlowsStatusResponse[]> GetFlowsStatus(GetFlowsStatusRequest getFlowsStatusRequest);
        Task SetFlowAction(string signFlowId, SetFlowActionRequest setFlowActionRequest);
        Task<byte[]> GetFlowAttachmentField(string signFlowId,GetFlowAttachmentFieldRequest getFlowAttachmentFieldRequest);
        Task<GetFlowMetadataResponse> GetFlow(string signFlowId);
        Task<byte[]> GetFlowAttachments(string signFlowId);
        Task<GetFlowStatusResponse> GetFlowStatus(string signFlowId);
        Task<string> AddTemplate(ExAddTemplateRequest exAddTemplateRequest);
        Task UpdateTemplate(string templateId, ExUpdateTemplateRequest exUpdateTemplateRequest);
        Task<CreateFlowFromTemplateResponse> CreateFlowFromTemplate(string templateId, CreateFlowFromTemplateRequest createFlowFromTemplateRequest);
        Task<GetExTemplateInfoResponse> GetTemplate(string templateId);
        Task DeleteUserTemplate(string templateId, DeleteTemplateRequest deleteTemplateRequest);
        Task<GetUserTemplatesResponse[]> GetUserTemplates(ParticipantKeyType sreachType, string searchValue);
        Task<List<GetGroupsResponseWithUsersKey>> GetUserGroups(ParticipantKeyType sreachType, string searchValue);
        Task SetSignatures(string signFlowId, ExSetSignFlowRequest exSetSignFlowRequest);
        Task<string> CreateVRMeeting(CreateVRMeetingRequest createVRRoomRequest);
        Task<GetVRMeetingsResponse> SearchVRMeetings(GetVRMeetingsRequest getVRMeetingsRequest);
        Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowDatat);
        Task<IEnumerable<string>> SearchFlow(GetFlowsByFilterRequest getFlowsByFilterRequest);
        Task<ExAddKitResponse> AddKit(ExAddKitRequest createKitRequest);
        Task UpdateKit(string kitId, ExUpdateKitRequest updateKitRequest);
        Task<ExGetKitInfoResponse> GetKit(string kitId);
        Task ReplaceSigner(ExReplaceSignerRequest exReplaceSignerRequest);
        Task<IEnumerable<ExGetKitsResponse>> GetKits();
        Task<string> AddFlowToVRMeeting(string vrMeetingId, string signflowId);
        Task UpdateVRMeeting(string vrMeetingId, UpdateVRMeetingRequest updateVRMeetingRequest);
        Task<string> AddAttachmentAsBase64ToFlow(string signFlowId, AddAttachmentBase64ToFlowRequest addAttachmentToFlowRequest);
        Task DeleteAttachmentFromTemplate(string templateId, string attachmentId);
        Task<string> AddAttachmentToTemplate(string templateId, AddAttachmentToFlowRequest addAttachmentRequest);
    }
}
