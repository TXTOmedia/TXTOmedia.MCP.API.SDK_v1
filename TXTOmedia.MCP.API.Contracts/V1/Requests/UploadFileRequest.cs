using System.IO;
using Microsoft.AspNetCore.Http;

namespace TXTOmedia.MCP.API.Contracts.V1.Requests
{
    public class UploadFileRequest
    {
        /// <summary>
        /// full local filepath included a filename extension.
        /// allowed file are:
        /// XML,
        /// DITA,
        /// DITAMAP,
        /// ZIP,
        /// WAV,
        /// MP3,
        /// MP4,
        /// PNG,
        /// EPS,
        /// SVG,
        /// JPG,
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// (optional) The id that will be used as the output filename.
        /// </summary>
        public string Fileid { get; set; }
        /// <summary>
        /// (optional) A customer reference identifier, this will be storage with the batch and can be used as a cross reference between 2 data sources
        /// </summary>
        public string Customerrefid { get; set; }

    }
}
