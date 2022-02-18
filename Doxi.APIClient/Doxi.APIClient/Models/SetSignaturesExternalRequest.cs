

using System.Collections.Generic;


namespace Doxi.APIClient
{
    public class SetSignaturesExternalRequest
    {
        
        public string SignFlowId { get; set; }

        
        public string SignerEmail { get; set; }

        
        public string DeclineComments { get; set; }

        public SignAction signAction { get; set; }

        public string SignImageBase64 { get; set; }

        public string BrowserDetails { get; set; }

        public string IPAddress { get; set; }

        public FlowElementSignerData[] FlowElements { get; set; }
        public IEnumerable<string> AttachedFiles { get; set; }
    }
}
