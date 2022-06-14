using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace Doxi.APIClient.Tests
{
    public class FlowsTests
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
        public async Task GetAllFlows_Test()
        {
            var result = await _doxiClient.GetAllFlows();
        }

        [Test]
        public async Task AddSignFlow_Test()
        {
            var pdfFile = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "emptyPDF.pdf"));
            var result = await _doxiClient.AddSignFlow(new ExCreateFlowRequestBase
            {
                Description = "Test flow",
                SenderKey = new ParticipantKey<ParticipantKeyType>
                {
                    Type = ParticipantKeyType.UserEmail,
                    Key = "ronenr@consist.co.il"
                },
                DocumentFileName = "testPDF.pdf",
                FlowElements = new[]
                {
                    new ExFlowElement
                    {
                        PageNumber = 1,
                        Position = new ElementPosition
                        {
                            Top = 0,
                            Left = 0,
                            Height = 50,
                            Width = 100,
                        },
                        SignerKey = new ParticipantKey<ParticipantKeyType>
                        {
                            Type = ParticipantKeyType.UserEmail,
                            Key = "john@someDomain.com"
                        },
                        ElementType = ElementType.Sign
                    }
                },
                Users = new[]
                {
                    new ExUser
                    {
                        Email = "john@someDomain.com",
                        FirstName = "John",
                        LastName = "Doe"
                    }
                }
            },pdfFile );
        }


    }
}