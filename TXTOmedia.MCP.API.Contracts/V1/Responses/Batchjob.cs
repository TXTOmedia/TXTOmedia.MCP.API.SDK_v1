using System.Collections.Generic;

namespace TXTOmedia.MCP.API.Contracts.V1.Responses
{
    public class Batchjob
    {
        public string BatchId { get; set; }
        public string UploadedFileName { get; set; }
        public string TimeStamp { get; set; }
        public string eTag { get; set; }
        public string FileId { get; set; }

        public IList<BatchOutput> BatchOutput { get; set; }
        public IList<Batch> Status { get; set; }

    }

    public class Batch
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string TimeStamp { get; set; }
    }

    /// <summary>
    /// Batch output files
    /// </summary>
    public class BatchOutput
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string Filename { get; set; }
        public string RequestId { get; set; }
        public string TimeStamp { get; set; }
    }
}
