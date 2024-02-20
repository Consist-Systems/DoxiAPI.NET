using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Consist.Doxi.Domain.WebHooks;
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
        Task<byte[]> GetFlowAttachmentField(string signFlowId, GetFlowAttachmentFieldRequest getFlowAttachmentFieldRequest);
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
        Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowData);
        Task<IEnumerable<string>> SearchFlow(GetFlowsByFilterRequest getFlowsByFilterRequest);
        Task<ExAddKitResponse> AddKit(ExAddKitRequest createKitRequest);
        Task UpdateKit(string kitId, ExUpdateKitRequest updateKitRequest);
        Task<ExGetKitInfoResponse> GetKit(string kitId);
        Task ReplaceSigner(ExReplaceSignerRequest exReplaceSignerRequest);
        Task<IEnumerable<ExGetKitsResponse>> GetKits();
        Task AddFlowToVRMeeting(string vrMeetingId, string signflowId);
        Task UpdateVRMeeting(string vrMeetingId, UpdateVRMeetingRequest updateVRMeetingRequest);
        Task<AddAttachmentAsBase64ToFlowResponse> AddAttachmentAsBase64ToFlow(string signFlowId, AddAttachmentBase64ToFlowRequest addAttachmentToFlowRequest);
        Task DeleteAttachmentFromTemplate(string templateId, string attachmentId);
        Task<string> AddAttachmentToTemplate(string templateId, AddAttachmentToFlowRequest addAttachmentRequest);
        Task<GetDocumentInfoResponse> DocumentInfo(byte[] document);
        Task<GetDocumentInfoResponse> DocumentInfoBase64(GetDocumentInfoRquest getDocumentInfoRquest);
        Task<SearchInDocumentResponse> SearchInDocumentBase64(SearchInDocumentBase64Request request);
        Task<SearchInDocumentResponse> SearchInDocument(byte[] file, SearchInDocumentRequest request);
        Task<byte[]> MergeDocuments(IEnumerable<byte[]> documents);
        Task<AddWebHookSubscriptionResponse> AddSubscription(WebhookSubscription webhookSubscription);
        Task<WebhookPayload> WebHookCheck(WebhookSubscription webhookSubscription);
        Task<IEnumerable<GetWebhookSubscriptionsResponse>> GetAllWebhookSubscription();
        Task<IEnumerable<SearchWebhookCallLogsResponse>> SearchWebhookCallLogs(string subscriptionId, RequestWebhookSenderLog requestWebhook);
        Task UpdateWebhookSubscription(string subscriptionId, WebhookSubscription webhookSubscription);
        Task DeleteSubscription(string subscriptionId);
        Task<byte[]> GetFormSettings(string compnayId, string formId);
    }
}
