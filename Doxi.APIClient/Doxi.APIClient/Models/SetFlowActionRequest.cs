

namespace Doxi.APIClient
{
    public class SetFlowActionRequest
    {
        /// <summary>
        /// FlowAction:
        ///  StopFlow=0
        ///  ResendDeclinedFlow=1
        ///  SendReminder=2
        ///  ArchiveFlow=3
        /// </summary>
        
        public FlowExternalAction FlowAction { get; set; }

        
        public string SignFlowId { get; set; }

        /// <summary>
        ///  Required in FlowExternalAction
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///  Required in FlowExternalAction
        /// </summary>
        public bool? IsRecover { get; set; }

        /// <summary>
        /// Required in SendReminder
        /// </summary>
        public string UserEmail { get; set; }
    }

    public enum FlowExternalAction
    {
        StopFlow,
        ResendDeclinedFlow,
        SendReminder,
        ArchiveFlow,
        ReleaseFlow
    }
}
