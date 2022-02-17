using Doxi.Domain.Models.RequestResponce;
using System.Threading.Tasks;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        public Task<byte[]> GetFlowAttachments(string signFlowId)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> GetFlowAttachmentField(string signFlowId, string signerEmail, string elementLabel)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> AddAttachmentToFlow(AddAttachmentToFlowRequest addAttachmentToFlowRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
