


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Doxi.APIClient
{
    public class CreateFlowRequestBase
    {

        
        public string DocumentFileName { get; set; }

        
        public string SenderUserName { get; set; }

        
        
        public string Description { get; set; }

        
        
        public ExternalFlowElement[] FlowElements { get; set; }

        [DefaultValue(SendMethodType.SingleSignerOneAfterTheOther)]
        
        public SendMethodType SendMethodType { get; set; }

        public ExUser[] Recipients { get; set; }

        public bool IsSendApprovalMailToAllSigners { get; set; }

        public bool IsAutomaticRemainder { get; set; }

        public int DayesForAutomaticRemainder { get; set; }

        public string SignFlowDescriptionMessage { get; set; }


        public KeyValuePair<string, string>[] CustomFields { get; set; }

        
        
        public ExUser[] Users { get; set; }
        public string PackageId { get; set; }
        public string PackageName { get; set; }

        public bool IsNoSend { get; set; }

        public bool IsNoNotificationMails { get; set; }


        public string PreliminaryText { get; set; }

        [Obsolete]
        public bool IsNoDecline { get; set; }

    }
}