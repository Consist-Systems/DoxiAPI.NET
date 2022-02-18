
using System;
using System.Collections.Generic;

namespace Doxi.APIClient
{
    public class GetFlowStatusResponse
    {
        public string SignFlowId { get; set; }

        public SignerInFlow[] Signers { get; set; }

        public string Sender { get; set; }

        public string SenderEmail { get; set; }

        public DateTime CreateDate { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public KeyValuePair<string, string>[] CustomFields { get; set; }
    }
}