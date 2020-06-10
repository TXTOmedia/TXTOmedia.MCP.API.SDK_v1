namespace TXTOmedia.MCP.API.Contracts.V1.Responses
{

    /// <summary>
    /// Upload response
    /// </summary>
    public class Uploadresponse
    {
        /// <summary>
        /// Status
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// filename which has been uploaded
        /// </summary>
        public string filename { get; set; }
        /// <summary>
        /// batch id this id will give you more information after a the upload.
        /// </summary>
        public string  batchid { get; set; }
        /// <summary>
        /// File id.
        /// </summary>
        public string  fileid { get; set; }
        /// <summary>
        /// Customer refer id 
        /// </summary>
        public string  customerrefid { get; set; }
        /// <summary>
        /// a callback url for the batch id information
        /// </summary>
        public string processurl { get; set; }
        /// <summary>
        /// the uploaded customer.
        /// </summary>
        public string customer { get; set; }
    }
}
