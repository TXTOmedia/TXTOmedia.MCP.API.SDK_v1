using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TXTOmedia.MCP.API.Contracts.V1.Requests;
using TXTOmedia.MCP.API.Contracts.V1.Responses;

namespace TXTOmedia.MCP.API.SDK
{
    [Headers("Authorization: ApiKey")]
    public interface ITxtomediaApi
    {
        // Speech
        [Get("/api/v1/speech/voicelist")]
        Task<ApiResponse<Response<VoiceFactoryVoicesResponse>>> Voicelist();

        [Get("/api/v1/speech/previewvoice/{speechPreviewRequest.VoiceId}/{speechPreviewRequest.Text}")]
        Task<ApiResponse<HttpContent>> Previewvoice(CreateSpeechPreviewRequest speechPreviewRequest);

        // Status
        [Get("/api/v1/status/batch/{batchid}")]
        Task<ApiResponse<Response<Batchjob>>> Batch(string batchid);

        [Get("/api/v1/status/fragment/{fileid}")]
        Task<ApiResponse<Response<FragmentStatus>>> Fragment(string fileid);

        [Get("/api/v1/status/mediatitle/{fileid}")]
        Task<ApiResponse<Response<MediaTitleStatus>>> Mediatitle(string fileid);

        // download
        [Get("/api/v1/download/fragment/{fileid}")]
        Task<ApiResponse<Response<DownloadResponse>>> Fragment([AliasAs("FileId")]GetDownloadFragmentRequest request);
        [Get("/api/v1/download/mediafile/{fileid}")]
        Task<ApiResponse<Response<DownloadResponse>>> MediaTitle([AliasAs("FileId")]GetDownloadMediatitleRequest request);

        // Upload
        [Multipart]
        [Post("/api/v1/upload/smallfileupload/{customerrefid")]
        Task<ApiResponse<Response<Uploadresponse>>> SmallFileUploadAsync(string customerrefid, StreamPart uploadFile);
    }
}
