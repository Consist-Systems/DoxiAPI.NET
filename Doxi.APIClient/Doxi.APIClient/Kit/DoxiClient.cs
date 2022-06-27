using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient 
    {
        private const string KIT_BASE = "kit";

        public async Task<ExAddKitResponse> AddKit(ExAddKitRequest createKitRequest)
        {
            return await GetServiceBaseUrl()
                .AppendPathSegment(KIT_BASE)
                .PostJsonAsync(createKitRequest)
                .ReceiveJson<ExAddKitResponse>();
        }

        public async Task UpdateKit(string kitId, ExUpdateKitRequest updateKitRequest)
        {
            await GetServiceBaseUrl()
               .AppendPathSegment(KIT_BASE)
               .AppendPathSegment(kitId)
               .PutJsonAsync(updateKitRequest);
        }

        public async Task<ExGetKitInfoResponse> GetKit(string kitId)
        {
            return await GetServiceBaseUrl()
                 .AppendPathSegment(KIT_BASE)
                 .AppendPathSegment(kitId)
                 .GetJsonAsync<ExGetKitInfoResponse>();
        }
    }
}
