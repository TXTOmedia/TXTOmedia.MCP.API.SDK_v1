using System.Collections.Generic;

namespace TXTOmedia.MCP.API.Contracts.V1.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse(){}

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }
        
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
