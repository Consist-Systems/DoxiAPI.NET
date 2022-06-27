using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
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
    public class VirtualRoomTests
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
        public async Task CreateVRMeeting_Test()
        {
            var result = await _doxiClient.CreateVRMeeting(new CreateVRMeetingRequest
            {
                MeetingDescription = "פגישת VR",
                MeetingDateTime = new DateTime(2022, 06, 27, 14, 0, 0),
                SignFlowsIds = new[]
                {
                    "99add5fd-e0f7-495d-a85a-14e5de92f60f"
                },
                RoomHostUser = new ParticipantKey<ParticipantKeyType>
                {
                    Key = "dudim@consist.co.il",
                    Type = ParticipantKeyType.UserEmail
                },
                Participants = new List<ParticipantKey<ParticipantKeyType>>
                {
                    new ParticipantKey<ParticipantKeyType>
                    {
                        Key = "dudim@consist.co.il",
                        Type = ParticipantKeyType.UserEmail
                    },
                    new ParticipantKey<ParticipantKeyType>
                    {
                        Key = "test@consist.co.il",
                        Type = ParticipantKeyType.UserEmail
                    }
                }
            });
        }

        [Test]
        public async Task SearchVRMeetings_Test()
        {
            var result = await _doxiClient.SearchVRMeetings(new GetVRMeetingsRequest
            {
                SignFlowId = "99add5fd-e0f7-495d-a85a-14e5de92f60f",
                Host = new ParticipantKey<ParticipantKeyType>
                {
                    Key = "dudim@consist.co.il",
                    Type = ParticipantKeyType.UserEmail
                }
                
            });
        }
    }
}
