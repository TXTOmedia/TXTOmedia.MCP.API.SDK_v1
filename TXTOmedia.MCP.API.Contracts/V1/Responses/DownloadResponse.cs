using System.Collections.Generic;

namespace TXTOmedia.MCP.API.Contracts.V1.Responses
{
    public class DownloadResponse
    {
        public string FileId { get; set; }

        public IEnumerable<DownloadUrls> DownloadUrls { get; set; }
    }
}
