using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Consist.Doxi.Enums;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Doxi.APIClient.Tests
{
    public class WebHookTests
    {
        private IDoxiClient _doxiClient;
        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<FlowsTests>();

            var configuration = builder.Build();

            _doxiClient = new DoxiClient(
                configuration["idpUrl"],
                configuration["serviceUrl"],
                configuration["CompanyName"],
                configuration["UserName"],
                configuration["Password"]);
        }

        [Test]
        public async Task AddSubscription()
        {
            var result = await _doxiClient.AddSubscription(new Consist.Doxi.Domain.Models.ExternalAPI.WebhookSubscription()
            {
                Headers = {},
                IsActive = true,
                IsEncryptData = false,
                WebhookConsumer = new Consist.Doxi.Domain.Models.ExternalAPI.WebhookConsumer()
                {
                    Company = "rivka",
                    ContactInfo = "0504134333",
                    Description = ""
                },
                Webhooks = new List<string>() { ""},
                WebhookUri = ""
            });
        }

        [Test]
        public async Task WebHookCheck()
        {
            var result = await _doxiClient.WebHookCheck(new WebhookSubscription()
            {
                Headers = { },
                IsActive = true,
                IsEncryptData = false,
                WebhookConsumer = new Consist.Doxi.Domain.Models.ExternalAPI.WebhookConsumer()
                {
                    Company = "rivka",
                    ContactInfo = "0504134333",
                    Description = ""
                },
                WebhookEvents = null,
                Webhooks = new List<string>() { "" },
                WebhookUri = ""
                
            });
        }

        [Test]
        public async Task GetAllWebhookSubscription()
        {
            var result = await _doxiClient.GetAllWebhookSubscription();
        }

        [Test]
        public async Task SearchWebhookCallLogs()
        {
            var result = await _doxiClient.SearchWebhookCallLogs("bc15fb2e3644450d92b1b4e30aac6e14", new RequestWebhookSenderLog
            {
                FromDateTime = null,
                IsFailed = null,
                ToDateTime = null
            });
        }

        [Test]
        public async Task UpdateWebhookSubscription()
        {
             await _doxiClient.UpdateWebhookSubscription("bc15fb2e3644450d92b1b4e30aac6e14", new WebhookSubscription
            {
                Headers = { },
                IsActive = true,
                IsEncryptData = false,
                WebhookConsumer = new Consist.Doxi.Domain.Models.ExternalAPI.WebhookConsumer()
                {
                    Company = "",
                    ContactInfo = "0504134333",
                    Description = ""
                },
                WebhookEvents = null,
                Webhooks = new List<string>() { "" },
                WebhookUri = ""
            });
        }

        [Test]
        public async Task DeleteSubscription()
        {
             await _doxiClient.DeleteSubscription("bc15fb2e3644450d92b1b4e30aac6e14");
        }

    }
}

