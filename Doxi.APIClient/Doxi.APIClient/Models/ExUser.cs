using Newtonsoft.Json;


namespace Doxi.APIClient
{
    public class ExUser
    {
        
        public string Email { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string SmsPhoneNumber { get; set; }

        /// <summary>
        /// Password for opening the sign link 
        /// </summary>
        public string UserPassword { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Display when the user open the link
        /// for example: "Please enter your social security number"
        /// LanguageKey is the message with all supported languages
        /// </summary>
        //[Obsolete]
        public LanguageKey[] UserPasswordDescription { get; set; }


        public bool? IsDisableAttachment { get; set; }

        public bool? IsDisplayDownloadDocument { get; set; }

        public bool? IsSendFromExternal { get; set; }

        public bool IsSuspended { get; set; }

        public bool IsNoDecline { get; set; }
    }
}