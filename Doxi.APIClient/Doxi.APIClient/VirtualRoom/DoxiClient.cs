using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        private const string VRMEETING_BASE = "vrmeeting";

        public async Task<string> CreateVRMeeting(CreateVRMeetingRequest createVRRoomRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(VRMEETING_BASE)
                .PostJsonAsync(createVRRoomRequest)
                .ReceiveString();
        }

        public async Task<GetVRMeetingsResponse> SearchVRMeetings(GetVRMeetingsRequest getVRMeetingsRequest)
        {
            return await GetServiceBaseUrl()
               .AppendPathSegment(VRMEETING_BASE)
               .AppendPathSegment("search")
               .PostJsonAsync(getVRMeetingsRequest)
               .ReceiveJson<GetVRMeetingsResponse>();
        }

    }
}
