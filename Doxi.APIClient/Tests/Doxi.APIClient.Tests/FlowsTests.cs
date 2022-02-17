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
            var serviceUrl = "https://doxisign.consist.co.il:4433/Doxiapi";

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<FlowsTests>();

            var configuration = builder.Build();

            _doxiClient = new DoxiClient(
                serviceUrl,
                configuration["UserName"],
                configuration["Password"]);
        }

        [Test]
        public async Task GetAllFlows_Test()
        {
            var result = await _doxiClient.GetAllFlows();
        }
    }
}