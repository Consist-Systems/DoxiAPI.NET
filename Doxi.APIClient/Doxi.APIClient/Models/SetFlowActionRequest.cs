﻿using System.ComponentModel.DataAnnotations;

namespace Doxi.Domain.Models.RequestResponce
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
        [Required]
        public FlowExternalAction FlowAction { get; set; }

        [Required]
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
