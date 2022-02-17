namespace Doxi.Domain.Models.RequestResponce
{
    public class AddAttachmentToFlowRequest
    {
        /// <summary>
        /// Id of the Doxi flow 
        /// </summary>
        public string SignFlowId { get; set; }

        /// <summary>
        /// file stream to add to flow
        /// </summary>
        public byte[] FileByte { get; set; }

        public string FileName { get; set; }

        /// <summary>
        /// User that add the file to the flow
        /// </summary>
        public string UserMail { get; set; }

    }
}
