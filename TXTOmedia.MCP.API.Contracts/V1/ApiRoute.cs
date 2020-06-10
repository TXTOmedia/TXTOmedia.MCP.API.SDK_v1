using System;
using System.Collections.Generic;
using System.Text;

namespace TXTOmedia.MCP.API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Downloads
        {
            public const string fragment = Base + "/download/fragment/{FileId}";

            public const string mediafile = Base + "/download/mediafile/{FileId}";
        }

        public static class Speech
        {
            public const string GetAll = Base + "/speech/voicelist";

            public const string GetpreviewVoice = Base + "/speech/previewvoice/{VoiceId}/{Text}";
        }

        public static class Status
        {
            public const string Batch = Base + "/status/batch/{batchid}";

            public const string Fragment = Base + "/status/fragment/{fileid}";

            public const string MediaTitle = Base + "/status/mediatitle/{fileid}";
        }

        public static class Upload
        {
            public const string SmallUploadfiles = Base + "/upload/smallfileupload/{customerrefid}";

        }
    }
}
