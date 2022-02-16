using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        public Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetFlowAttachmentField(GetFlowAttachmentFieldRequest getFlowAttachmentFieldRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetFlowAttachments(string signFlowId)
        {
            throw new System.NotImplementedException();
        }
    }
}
