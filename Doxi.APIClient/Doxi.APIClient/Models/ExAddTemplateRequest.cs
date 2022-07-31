

using System;


namespace Doxi.APIClient
{
    public class ExAddTemplateRequest
    {
        
        public string DocumentFileName { get; set; }

        
        public string SenderUserName { get; set; }

        
        public string TemplateName { get; set; }

        public ExternalTemplatFlowElement[] FlowElements { get; set; }
        public ExTemplateUser[] Users { get; set; }

        [Obsolete]
        public bool IsNoDecline { get; set; }

        
        public string Base64DocumentFile { get; set; }

        public SendMethodType SendMethodType { get; set; }

    }
}
