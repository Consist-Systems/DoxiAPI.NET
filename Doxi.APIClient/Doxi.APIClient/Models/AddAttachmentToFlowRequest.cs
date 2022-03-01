namespace Doxi.APIClient
{
    public class AddAttachmentToFlowRequest
    {
        /// <summary>
        /// Id of the Doxi flow 
        /// </summary>
        public string SignFlowId { get; set; }

        public string FileName { get; set; }

        public byte[] FileByte { get; set; }

        /// <summary>
        /// User that add the file to the flow
        /// </summary>
        public string UserMail { get; set; }

    }
}
