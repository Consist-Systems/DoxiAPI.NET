namespace Doxi.APIClient
{
    public class AddSignFlowResponse
    {
        public string SignFlowId { get; set; }

        public SignerLink[] SignersLink { get; set; }
    }

    public class CreateFlowFromTemplateResponce : AddSignFlowResponse
    {

    }

    public class SignerLink
    {
        public string SignerId { get; set; }

        public string Link { get; set; }
    }
}
