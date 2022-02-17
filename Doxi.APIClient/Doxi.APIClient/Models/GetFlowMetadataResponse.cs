using Doxi.Domain.Models.FrontModels;
using System.Collections.Generic;

namespace Doxi.Domain.Models.RequestResponce
{
    public class GetFlowMetadataResponse
    {
        public IEnumerable<ExternalFlowElement> FlowElements { get; set; }

        public string DeclineReason { get; set; }
    }
}
