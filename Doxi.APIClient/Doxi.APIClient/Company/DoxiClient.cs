using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        private const string COMPANY_BASE = "company";

        public async Task<byte[]> GetFormSettings(string compnayId, string formId)
        {
            var result = await GetServiceBaseUrl()
                 .AppendPathSegment(COMPANY_BASE)
                 .AppendPathSegment($"{compnayId}/{formId}")
                 .GetAsync();

            var responseString = await result.ResponseMessage.Content.ReadAsStringAsync();
            var resultAsBytes = Encoding.UTF8.GetBytes(responseString);
            return resultAsBytes;
        }
    }
}
