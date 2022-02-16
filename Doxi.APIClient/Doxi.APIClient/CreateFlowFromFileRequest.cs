using Consist.Doxi.Domain.Extentions;
using Consist.Doxi.Domain.Models;
using Consist.Doxi.Enums;
using System;

namespace Doxi.APIClient
{
    public class CreateFlowFromFileRequest
    {
        private ParticipantKey<ParticipantKeyType> _senderKey;
        public ParticipantKey<ParticipantKeyType> SenderKey
        {
            get
            {
                return _senderKey = _senderKey.Get(SenderMail, ParticipantKeyType.UserEmail); ;
            }
            set
            {
                _senderKey = value;
            }
        }
        [Obsolete]
        public string SenderMail { get; set; }
        public byte[] File { get; set; }
    }
}
