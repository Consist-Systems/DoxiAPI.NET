

using System;
using System.ComponentModel.DataAnnotations;

namespace Doxi.APIClient
{
    public class ExAddTemplateRequest
    {
        [Required]
        public string DocumentFileName { get; set; }

        [Required]
        public string SenderUserName { get; set; }

        [Required]
        public string TemplateName { get; set; }

        public ExternalTemplatFlowElement[] FlowElements { get; set; }
        public ExTemplateUser[] Users { get; set; }

        [Obsolete]
        public bool IsNoDecline { get; set; }

        [Required]
        public string Base64DocumentFile { get; set; }


    }
}
