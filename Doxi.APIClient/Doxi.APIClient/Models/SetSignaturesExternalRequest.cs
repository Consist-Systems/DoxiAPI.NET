

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doxi.APIClient
{
    public class SetSignaturesExternalRequest
    {
        [Required]
        public string SignFlowId { get; set; }

        [Required]
        public string SignerEmail { get; set; }

        [StringLength(4000)]
        public string DeclineComments { get; set; }

        public SignAction signAction { get; set; }

        public string SignImageBase64 { get; set; }

        public string BrowserDetails { get; set; }

        public string IPAddress { get; set; }

        public FlowElementSignerData[] FlowElements { get; set; }
        public IEnumerable<string> AttachedFiles { get; set; }
    }
}
