using Doxi.Service.Interfaces.Enums;
using System;
using System.Collections.Generic;

namespace Doxi.Domain.Models.RequestResponce
{
    public class GetFlowsByFilterRequest
    {
        public IEnumerable<KeyValuePair<string, string>> CustomFields { get; set; }

        public SignatureFlowStatus? SignatureFlowStatus { get; set; }

        public string SignerEmail { get; set; }

        public string SignerPhone { get; set; }

        public string SenderUserName { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
