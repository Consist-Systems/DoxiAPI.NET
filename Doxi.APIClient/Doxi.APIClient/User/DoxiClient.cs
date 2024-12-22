using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using Doxi.APIClient.Models;
using Flurl.Http;
using System;
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
               .GetJsonAsync<IEnumerable<BaseUser>>()
               .ConfigureAwait(false);

            if (users == null)
            {
                return string.Empty;
            }
            var userId = users.First().id;
            return userId;
        }

        /// <summary>
        /// Search users by filter
        /// </summary>
        /// <param name="queryParams">Keys:email,username,idpUserId,enabled</param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsers(Dictionary<string, object> queryParams)
        {
            var users = await GetIDPServiceBaseUrl()
               .AppendPathSegment("auth/admin/realms")
               .AppendPathSegment(_companyName)
               .AppendPathSegment("users")
               .SetQueryParams(queryParams)
               .GetJsonAsync<IEnumerable<KeycloakUser>>()
               .ConfigureAwait(false);

            if (users == null)
            {
                return null;
            }

            foreach (var user in users)
            {
                user.MobilePhone = user.Attributes.GetKeycloakAttributeValue("phone_number");
                user.Company = user.Attributes.GetKeycloakAttributeValue("company");
                user.Title = user.Attributes.GetKeycloakAttributeValue("title");
                user.IsAllowReceivingSMS = user.Attributes.GetKeycloakAttributeValue("receive_sms") == "True";
                user.IsAllowReceivingMails = user.Attributes.GetKeycloakAttributeValue("receive_mail") == "True";
                var strLastLoginTime = user.Attributes.GetKeycloakAttributeValue("last_login_time_utc");
                user.LastLoginTime = strLastLoginTime != null? DateTime.ParseExact(strLastLoginTime, "MM/dd/yyyy HH:mm:ss", null): (DateTime?)null;
                user.IdDeleted = user.Attributes.GetKeycloakAttributeValue("deleted") == "True";
                user.PreferredLanguageCode = user.Attributes.GetKeycloakAttributeValue("preferred_language_code");
                user.PreferredTimezone = user.Attributes.GetKeycloakAttributeValue("preferred_timezone");

                user.CreatedTime = DateTimeOffset.FromUnixTimeMilliseconds(user.CreatedTimestamp).UtcDateTime;
            }
            return users;
        }
    }
}