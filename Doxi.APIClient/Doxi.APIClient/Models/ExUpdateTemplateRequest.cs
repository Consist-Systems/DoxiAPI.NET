
using System;


namespace Doxi.APIClient
{
    public class ExUpdateTemplateRequest
    {
        
        public string TemplateId { get; set; }

        [Obsolete]
        public string SenderUserName { get; set; }

        //TODO: Add this fields
        //public KeyValuePair<string, string>[] CustomFields { get; set; }

        //public string PackageId { get; set; }
        //public string PackageName { get; set; }

        
        public string TemplateName { get; set; }
        public ExternalTemplatFlowElement[] FlowElements { get; set; }
        public ExTemplateUser[] Users { get; set; }

        [Obsolete]
        public bool IsNoDecline { get; set; }
        public SendMethodType SendMethodType { get; set; }
    }
}
