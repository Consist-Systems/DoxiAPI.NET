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
        public async Task AddAttachmentToFlow_Test()
        {
            var pdfFile = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "emptyPDF.pdf"));

            var result = await _doxiClient.AddAttachmentToFlow(new AddAttachmentToFlowRequest
            {
                File = new FileData
                {
                    FileBytes = pdfFile,
                    Name = "emptyPDF.pdf"
                },
                SignFlowId = "6d1af0ba-cc5d-4d81-8ae3-c3bab595e8ad",
                UserAddedTheFile = new ParticipantKey<ParticipantKeyType>
                {
                    Key = "zivf@consist.co.il",
                    Type = ParticipantKeyType.UserEmail
                }
            });
        }

        [Test]
        public async Task GetFlowAttachments_Test()
        {
            var result = await _doxiClient.GetFlowAttachments("4174d583-0590-440e-bfb9-2f83eef58d2e");
        }

        [Test]
        public async Task AddAttachmentAsBase64ToFlow_Test()
        {
            var result = await _doxiClient.AddAttachmentAsBase64ToFlow("6d1af0ba-cc5d-4d81-8ae3-c3bab595e8ad",
                new Consist.Doxi.Domain.Models.ExternalAPI.AddAttachmentBase64ToFlowRequest
                {
                    File = new Consist.Doxi.Domain.Models.ExternalAPI.Base64File
                    {
                        File = "JVBERi0xLjANCjEgMCBvYmo8PC9UeXBlL0NhdGFsb2cvUGFnZXMgMiAwIFI+PmVuZG9iaiAyIDAgb2JqPDwvVHlwZS9QYWdlcy9LaWRzWzMgMCBSXS9Db3VudCAxPj5lbmRvYmogMyAwIG9iajw8L1R5cGUvUGFnZS9NZWRpYUJveFswIDAgMyAzXT4+ZW5kb2JqDQp4cmVmDQowIDQNCjAwMDAwMDAwMDAgNjU1MzUgZg0KMDAwMDAwMDAxMCAwMDAwMCBuDQowMDAwMDAwMDUzIDAwMDAwIG4NCjAwMDAwMDAxMDIgMDAwMDAgbg0KdHJhaWxlcjw8L1NpemUgNC9Sb290IDEgMCBSPj4NCnN0YXJ0eHJlZg0KMTQ5DQolRU9G",
                        FileName = "emptyPDF.pdf"
                    },
                    UserAddedTheFile = new ParticipantKey<ParticipantKeyType>
                    {
                        Key = "zivf@consist.co.il",
                        Type = ParticipantKeyType.UserEmail
                    }
                });
        }

    }
}