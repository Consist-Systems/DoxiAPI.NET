namespace Doxi.APIClient
{
    public class ExTemplateUser
    {
        public int UserIndex { get; set; }
        public string Title { get; set; }
        public string FixedUserEMail { get; set; }
        public bool? IsDisableAttachment { get; set; }
        public bool? IsDisplayDownloadDocument { get; set; }
        public bool? IsSendFromExternal { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsNoDecline { get; set; }
        public bool IsChangable { get; set; }
    }
}
