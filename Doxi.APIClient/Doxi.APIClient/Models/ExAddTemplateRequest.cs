using Doxi.Domain.Attributes;
using Doxi.Domain.Models.FrontModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Doxi.Domain.Models.RequestResponce
{
    public class ExAddTemplateRequest
    {


        [Required]
        public string DocumentFileName { get; set; }

        [Required]
        public string SenderUserName { get; set; }

        //TODO: Add this fields
        //public KeyValuePair<string, string>[] CustomFields { get; set; }

        //public string PackageId { get; set; }
        //public string PackageName { get; set; }

        [Required]
        public string TemplateName { get; set; }

        [MobileSideBySideValidation]
        public ExternalTemplatFlowElement[] FlowElements { get; set; }
        public ExTemplateUser[] Users { get; set; }

        [Obsolete]
        public bool IsNoDecline { get; set; }

        [Required]
        //[PDFFile]
        public string Base64DocumentFile { get; set; }


    }
}
