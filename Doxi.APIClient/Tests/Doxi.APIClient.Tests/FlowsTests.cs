using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;
using System.IO;



namespace Doxi.APIClient.Tests
{
    public class FlowsTests
    {
        private IDoxiClient _doxiClient;
        private IConfiguration _configuration;
        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<FlowsTests>();

            _configuration = builder.Build();

            _doxiClient = new DoxiClient(
                _configuration["ServiceUrl"],
                _configuration["UserName"],
                _configuration["Password"]);
        }

        [Test]
        public async Task GetAllFlowsAsync_Test()
        {
            var result = await _doxiClient.GetAllFlows();
        }

        [Test]
        public void GetAllFlows_Test()
        {
            var result = _doxiClient.GetAllFlows().Result;
        }

        [Test]
        public async Task GetFlowStatus_Test()
        {
            var allFlows = await _doxiClient.GetAllFlows();

            var status = await _doxiClient.GetFlowStatus(allFlows.SignFlowsIds.First());
        }

        [Test]
        public async Task AddSignFlowByFileStream_Test()
        {
            var newFlowParams = new CreateFlowRequestBase
            {
                DocumentFileName = "testPdf.pdf",
                Description = "Test from Doxi API client",
                SenderUserName = _configuration["UserName"],
                FlowElements = new[]
                {
                    new ExternalFlowElement
                    {
                        PageNumber = 1,
                        ElementType = 0,
                        Position = new ElementPosition
                        {
                            Top = 0,
                            Left = 0,
                            Height = 50,
                            Width = 100,
                        },
                        UserEmail = "SomeMail@SomeDomain.com"
                    }
                },
                Users = new[]
                {
                    new ExUser
                    {
                        Email = "SomeMail@SomeDomain.com",
                        FirstName = "Test",
                        LastName = "User",
                    }
                }
            };
            var documentTest = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "../../../3pages.pdf"));
            var result = await _doxiClient.AddSignFlowByFileStream(newFlowParams, documentTest);
        }

        [Test]
        public async Task AddAttachmentToFlow_Test()
        {
            var documentTest = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "../../../3pages.pdf"));
            var allFlows =  await _doxiClient.GetAllFlows();

            await _doxiClient.AddAttachmentToFlow(new AddAttachmentToFlowRequest
            {
                FileByte = documentTest,
                FileName = "test.pdf",
                SignFlowId = allFlows.SignFlowsIds.Last(),
                UserMail = "ronenr@consist.co.il"
            });
        }

    }
}