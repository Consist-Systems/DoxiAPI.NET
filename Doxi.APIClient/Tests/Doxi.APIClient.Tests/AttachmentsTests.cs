using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Doxi.APIClient.Tests
{
    public class AttachmentsTests
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
        public async Task AddAttachmentToFlow()
        {
            var pdfFile = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "emptyPDF.pdf"));

            var result = await _doxiClient.AddAttachmentToFlow(new AddAttachmentToFlowRequest
            {
                File = new FileData
                {
                    FileBytes = pdfFile,
                    Name = "file name"
                },
                SignFlowId = "523dd3e9-c014-4860-9cf3-c02afe93ce15",
                UserAddedTheFile = new ParticipantKey<ParticipantKeyType>
                {
                    Key = "chenl@consist.co.il",
                    Type = ParticipantKeyType.UserEmail
                },
                UserMail = "chenl@consist.co.il"
            });
        }

        [Test]
        public async Task GetFlowAttachments()
        {
            var result = await _doxiClient.GetFlowAttachments("4174d583-0590-440e-bfb9-2f83eef58d2e");
        }

        [Test]
        public async Task AddAttachmentAsBase64ToFlow()
        {
            var result = await _doxiClient.AddAttachmentAsBase64ToFlow("aeb4d41d-7a7f-4156-857d-f6129dbae5eb",
                new Consist.Doxi.Domain.Models.ExternalAPI.AddAttachmentBase64ToFlowRequest
                {
                    File = new Consist.Doxi.Domain.Models.ExternalAPI.Base64File
                    {
                        File = "JVBERi0xLjANCjEgMCBvYmo8PC9UeXBlL0NhdGFsb2cvUGFnZXMgMiAwIFI+PmVuZG9iaiAyIDAgb2JqPDwvVHlwZS9QYWdlcy9LaWRzWzMgMCBSXS9Db3VudCAxPj5lbmRvYmogMyAwIG9iajw8L1R5cGUvUGFnZS9NZWRpYUJveFswIDAgMyAzXT4+ZW5kb2JqDQp4cmVmDQowIDQNCjAwMDAwMDAwMDAgNjU1MzUgZg0KMDAwMDAwMDAxMCAwMDAwMCBuDQowMDAwMDAwMDUzIDAwMDAwIG4NCjAwMDAwMDAxMDIgMDAwMDAgbg0KdHJhaWxlcjw8L1NpemUgNC9Sb290IDEgMCBSPj4NCnN0YXJ0eHJlZg0KMTQ5DQolRU9G",
                        FileName = "Base64File"
                    },
                    UserAddedTheFile = new ParticipantKey<ParticipantKeyType>
                    {
                        Key = "chenl@consist.co.il",
                        Type = ParticipantKeyType.UserEmail
                    }
                });
        }

    }
}