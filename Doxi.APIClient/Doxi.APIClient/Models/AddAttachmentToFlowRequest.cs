namespace Doxi.APIClient
{
    public class AddAttachmentToFlowRequest : Consist.Doxi.Domain.Models.ExternalAPI.AddAttachmentToFlowRequest
    {
        public FileData File { get; set; }
    }
}
