using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Doxi.APIClient.Tests
{
    public class KitTests
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
        public async Task AddKit_Test()
        {
            //var result = await _doxiClient.AddKit();
            
            var result = await _doxiClient.AddKit(new ExAddKitRequest
            {
                KitDescription = "בדיקה",
                SenderKey = new ParticipantKey<ParticipantKeyType>
                {
                    Key = "dudim@consist.co.il",
                    Type = ParticipantKeyType.UserEmail
                },
                Signer = new ExUser
                {
                    Email = "dudim@consist.co.il",
                    FirstName = "Dudi",
                    UserPassword = "305407439"
                },
                SendingMethods = new[]
                {
                    SendMethodTypes.EMail
                },
                Flows = new[]
                {
                    "99add5fd-e0f7-495d-a85a-14e5de92f60f"
                }
            });
        }

        [Test]
        public async Task UpdateKit_Test()
        {
            var updateKitRequest = new ExUpdateKitRequest
            {
                Flows = new[]
                {
                    "99add5fd-e0f7-495d-a85a-14e5de92f60f"
                }
            };
            var result =  _doxiClient.UpdateKit("648660de-a0ba-4555-b315-ff8c09dc68c7", updateKitRequest);
        }

        [Test]
        public async Task GetKit_Test()
        {
            var result = await _doxiClient.GetKit("d9bfbc3c-b614-4bbb-97ca-e92a71e3088c");
        }

        [Test]
        public async Task GetKits_Test()
        {
           var x=  await _doxiClient.GetKits();
        }

    }
}
