using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doxi.APIClient.Models
{
    public class EditFlowRequest
    {
        public FileData File { get; set; }
        public ParticipantKey<ParticipantKeyType> SenderKey { get; set; }
    }
}
