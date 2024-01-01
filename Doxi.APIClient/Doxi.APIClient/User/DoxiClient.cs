using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        private const string USER_BASE = "user";

        public async Task<List<GetGroupsResponseWithUsersKey>> GetUserGroups(ParticipantKeyType sreachType, string searchValue)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(USER_BASE)
                .AppendPathSegment(sreachType)
                .AppendPathSegment(searchValue)
                .AppendPathSegment("groups")
                .GetJsonAsync<List<GetGroupsResponseWithUsersKey>>();
        }

        public async Task<GetUserTemplatesResponse[]> GetUserTemplates(ParticipantKeyType sreachType, string searchValue)
        {
            return await GetServiceBaseUrl()
               .AppendPathSegment(USER_BASE)
               .AppendPathSegment(sreachType)
               .AppendPathSegment(searchValue)
               .AppendPathSegment("templates")
               .GetJsonAsync<GetUserTemplatesResponse[]>();
        }

    }
}