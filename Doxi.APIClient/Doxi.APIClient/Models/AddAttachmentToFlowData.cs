using Consist.Doxi.Domain.Models.ExternalAPI;
using Newtonsoft.Json;

namespace Doxi.APIClient
{
    public class AddAttachmentToFlowData : AddAttachmentToFlowRequest
    {
        [JsonIgnore]
        public new string SignFlowId { get; set; }
        [JsonIgnore]
        public string FileName { get; set; }
        [JsonIgnore]
        public byte[] FileByte { get; set; }
    }
}
