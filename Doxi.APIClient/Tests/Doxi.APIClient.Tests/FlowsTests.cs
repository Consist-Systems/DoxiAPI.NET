using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Doxi.APIClient.Tests
{
    public class FlowsTests
    {
        private IDoxiClient _doxiClient;
        [SetUp]
        public void Setup()
        {
            var idpUrl = "https://logintest.doxi-sign.com";
            var serviceUrl = "https://test.doxi-sign.com/api";

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<FlowsTests>();

            var configuration = builder.Build();

            _doxiClient = new DoxiClient(
                idpUrl,
                serviceUrl,
                configuration["CompanyName"],
                configuration["UserName"],
                configuration["Password"]);
        }

        [Test]
        public async Task GetAllFlows_Test()
        {
            var result = await _doxiClient.GetAllFlows();
            Assert.Pass();
        }
    }
}