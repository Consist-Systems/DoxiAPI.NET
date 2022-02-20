
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {

        public async Task<GetGroupsResponse> GetGroups(string userName)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(userName)] = userName,
            };
             return await GetServiceBaseUrl()
                .AppendPathSegment(nameof(GetGroups))
                .SetQueryParams(queryParams)
                .GetJsonAsync<GetGroupsResponse>();
        }
    }
}
