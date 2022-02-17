using Doxi.Domain.Attributes;
using Doxi.Domain.Models.FrontModels;
using Doxi.Service.Interfaces.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Doxi.Domain.Models.RequestResponce
{
    public class CreateFlowRequestBase
    {

        [Required]
        public string DocumentFileName { get; set; }

        [Required]
        public string SenderUserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [MustHaveOneElement]
        [MobileSideBySideValidation]
        public ExternalFlowElement[] FlowElements { get; set; }

        [DefaultValue(SendMethodType.SingleSignerOneAfterTheOther)]
        [EnumDataType(typeof(SendMethodType), ErrorMessage = "Invalid SendMethodType")]
        public SendMethodType SendMethodType { get; set; }

        public ExUser[] Recipients { get; set; }

        public bool IsSendApprovalMailToAllSigners { get; set; }

        public bool IsAutomaticRemainder { get; set; }

        public int DayesForAutomaticRemainder { get; set; }

        public string SignFlowDescriptionMessage { get; set; }


        public KeyValuePair<string, string>[] CustomFields { get; set; }

        [Required]
        [MustHaveOneElement]
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