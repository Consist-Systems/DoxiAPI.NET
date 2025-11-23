using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Consist.Doxi.External.Models.Models.ExternalAPI.Webhook;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        private const string WEBHOOK_BASE = "webhook";

        public async Task<AddWebHookSubscriptionResponse> AddSubscription(WebhookSubscription webhookSubscription)
        {
            return await GetServiceBaseUrl()
                     .AppendPathSegment(WEBHOOK_BASE)
                     .PostJsonAsync(webhookSubscription)
                     .ReceiveJson<AddWebHookSubscriptionResponse>();
        }

        public async Task<WebhookPayload> WebHookCheck(WebhookSubscription webhookSubscription)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(WEBHOOK_BASE)
                .AppendPathSegment("test")
                .PostJsonAsync(webhookSubscription)
                .ReceiveJson<WebhookPayload>();
        }

        public async Task<IEnumerable<GetWebhookSubscriptionsResponse>> GetAllWebhookSubscription()
        {
            return await GetServiceBaseUrl()
                 .AppendPathSegment(WEBHOOK_BASE)
                 .GetJsonAsync<IEnumerable<GetWebhookSubscriptionsResponse>>();
        }

        public async Task<IEnumerable<SearchWebhookCallLogsResponse>> SearchWebhookCallLogs(string subscriptionId, RequestWebhookSenderLog requestWebhook)
        {
            return await GetServiceBaseUrl()
                     .AppendPathSegment(WEBHOOK_BASE)
                     .AppendPathSegment($"SearchWebhookCallLogs/{subscriptionId}")
                     .PostJsonAsync(requestWebhook)
                     .ReceiveJson<IEnumerable<SearchWebhookCallLogsResponse>>();
        }

        public async Task UpdateWebhookSubscription(string subscriptionId, WebhookSubscription webhookSubscription)
        {
            await GetServiceBaseUrl()
                      .AppendPathSegment(WEBHOOK_BASE)
                     .AppendPathSegment(subscriptionId)
                     .PutJsonAsync(webhookSubscription);
        }

        public async Task DeleteSubscription(string subscriptionId)
        {
            await GetServiceBaseUrl()
                .AppendPathSegment(WEBHOOK_BASE)
                .AppendPathSegment(subscriptionId)
                .DeleteAsync();
        }

    }
}
