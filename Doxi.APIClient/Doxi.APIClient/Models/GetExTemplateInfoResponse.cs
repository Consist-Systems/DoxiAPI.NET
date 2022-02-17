using Doxi.Domain.Models.FrontModels;
using Doxi.Service.Interfaces.Enums;
using System;

namespace Doxi.Domain.Models.RequestResponce
{
    public class GetExTemplateInfoResponse
    {

        public string DocumentFileName { get; set; }

        public string SenderUserName { get; set; }

        //TODO: Add this fields
        //public KeyValuePair<string, string>[] CustomFields { get; set; }

        //public string PackageId { get; set; }
        //public string PackageName { get; set; }

        public string TemplateName { get; set; }
        public ExternalTemplatFlowElement[] FlowElements { get; set; }
        public ExTemplateUser[] Users { get; set; }

        public string Base64DocumentFile { get; set; }

        public SendMethodType SendMethodType { get; set; }

        [Obsolete]
        public bool IsNoDecline { get; set; }
    }
}
