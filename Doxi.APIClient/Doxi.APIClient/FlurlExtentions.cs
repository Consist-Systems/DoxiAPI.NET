using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public static class FlurlExtentions
    {
        private static string GetAccessToken(string url, string realm, string userName, string password) => GetAccessTokenAsync(url, realm, userName, password).GetAwaiter().GetResult();

        internal static IFlurlRequest WithAuthentication(this IFlurlRequest request,string url, string realm, string userName, string password,string token)
        {
            if(token == null)
                token = GetAccessToken(url, realm, userName, password);

            return request.WithOAuthBearerToken(token);
        }

        public static async Task<string> GetAccessTokenAsync(string url, string realm, string userName, string password)
        {
            var result = await url
                .AppendPathSegment($"/auth/realms/{realm}/protocol/openid-connect/token")
                .WithHeader("Accept", "application/json")
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("client_id", "doxi")
                })
                .ReceiveJson()
                .ConfigureAwait(false);

            string accessToken = result.access_token.ToString();

            return accessToken;
        }

    }
}
