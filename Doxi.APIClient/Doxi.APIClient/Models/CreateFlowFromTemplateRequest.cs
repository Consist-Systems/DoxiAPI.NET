
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doxi.APIClient
{
    public class CreateFlowFromTemplateRequest
    {
        [Required]
        public string TemplateId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SenderUserName { get; set; }
        public string PreliminaryText { get; set; }
        public KeyValuePair<string, string>[] CustomFields { get; set; }

        public ExUser[] Users { get; set; }

        public ExUser[] Recipients { get; set; }

        public bool IsSendApprovalMailToAllSigners { get; set; }

        public bool IsNoSend { get; set; }

        public bool IsNoNotificationMails { get; set; }

        public ReadOnlyField[] ReadOnlyFields { get; set; }

        public string PackageId { get; set; }

        public string PackageName { get; set; }
    }
}
