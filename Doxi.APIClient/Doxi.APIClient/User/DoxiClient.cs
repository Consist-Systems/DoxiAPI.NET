using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using Flurl.Http;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> GetUserIdByEmail(string email)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(email)] = email,
            };
            var users = await GetIDPServiceBaseUrl()
               .AppendPathSegment("auth/admin/realms")
               .AppendPathSegment(_companyName)
               .AppendPathSegment("users")
               .SetQueryParams(queryParams)
               .GetJsonAsync<IEnumerable<UserId>>()
               .ConfigureAwait(false);

            if (users == null)
            {
                return string.Empty;
            }
            var userId = users.First().id;
            return userId;
        }

        public class UserId
        {
            public string id { get; set; }
            public string email { get; set; }
        }
    }
}