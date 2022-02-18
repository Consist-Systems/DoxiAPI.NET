
using System;

namespace Doxi.APIClient
{
    public class SignerInFlow
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime? SendDate { get; set; }

        public DateTime? StatusDate { get; set; }

        public string Status { get; set; }

        public DateTime? LastReminderDate { get; set; }

        public string Comments { get; set; }
        public NotificationSendStatus EmailStatus { get; set; }
        public NotificationSendStatus SMSStatus { get; set; }
        public bool ReminderEnabled { get; set; }
    }
}
