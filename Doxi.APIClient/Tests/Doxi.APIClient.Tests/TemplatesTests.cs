using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Doxi.APIClient.Tests
{
    public class TemplatesTests
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
        public async Task AddTemplate_Test()
        {
            var pdfFile = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "emptyPDF.pdf"));
            var templateId = await _doxiClient.AddTemplate(new ExAddTemplateRequest
            {
                TemplateName = "Test Template from API",
                SenderKey = new ParticipantKey<ParticipantKeyType>
                {
                    Type = ParticipantKeyType.UserEmail,
                    Key = "ronenr@consist.co.il"
                },
                Base64DocumentFile = Convert.ToBase64String(pdfFile),
                DocumentFileName = "Test.pdf",
                FlowElements = new[]
                {
                    new ExTemplatFlowElement
                    {
                        UserIndex = 0,
                        ElementType = ElementType.Sign,
                        Position = new ElementPosition
                        {
                            Top = 0,
                            Left = 0,
                            Width = 100,
                            Height = 50
                        },
                        PageNumber = 1,
                    }
                },
                Users = new[]
                {
                    new ExTemplateUser
                    {
                        UserIndex = 0,
                        FixedSignerKey = new ParticipantKey<ParticipantKeyType>
                        {
                            Type = ParticipantKeyType.UserEmail,
                            Key = "ronenr@consist.co.il"
                        }
                    }
                }
                
        });

            await _doxiClient.DeleteUserTemplate(templateId, new DeleteTemplateRequest
            {
                UserKey = new ParticipantKey<ParticipantKeyType>
                {
                    Type = ParticipantKeyType.UserEmail,
                    Key = "ronenr@consist.co.il"
                }
            });
        }


    }
}