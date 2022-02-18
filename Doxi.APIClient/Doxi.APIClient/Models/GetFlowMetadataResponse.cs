
using System.Collections.Generic;

namespace Doxi.APIClient
{
    public class GetFlowMetadataResponse
    {
        public IEnumerable<ExternalFlowElement> FlowElements { get; set; }

        public string DeclineReason { get; set; }
    }
}
