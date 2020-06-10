﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Refit;

namespace TXTOmedia.MCP.API.SDK.Sample
{
    class Program
    {
        private const string ApiKeyHeaderName = "ApiKey";

        // the API key for accessing TXTOmedia's MCP (Media Creation Platform) API
        private const string ApiKey = "YourKey";
        private const string ApiUrl = "Api Endpoint";

        static async Task Main()
        {
            Console.WriteLine("Hello TXTOmedia");

            // we are using a client to pass extra API Key header
            var client = new HttpClient(new HttpClientHandler())
            {
                BaseAddress = new Uri(ApiUrl)
            };
            client.DefaultRequestHeaders.Add(ApiKeyHeaderName, new[] { ApiKey });

            // setting up API
            var txtomediaApi = RestService.For<ITxtomediaApi>(client);

            //*************
            // Upload files
            //*************

            // upload a file to TXTOmedia
            var uploadAsync = await txtomediaApi.SmallFileUploadAsync(
                customerrefid: "My_company_ref_id",
                 uploadFile: new StreamPart(new FileStream("D:\\media.mp4", FileMode.Open), "media.mp4", "video/mp4")
                );

            // getting the response 
            Console.WriteLine("** UploadResponse");
            Console.WriteLine($"** StatusCode: {uploadAsync.StatusCode}");
            if (uploadAsync.StatusCode == HttpStatusCode.Unauthorized) Console.WriteLine(">> Check APIKey <<");
            Console.WriteLine();
                Console.WriteLine(JsonSerializer.Serialize(uploadAsync.Content, new JsonSerializerOptions() { WriteIndented = true }));

            if (uploadAsync.Content != null)
            {
                var batchStatus = await txtomediaApi.Batch(uploadAsync.Content.Data.batchid);
                Console.WriteLine("** BatchStatus");
                Console.WriteLine(JsonSerializer.Serialize(batchStatus.Content,
                    new JsonSerializerOptions() { WriteIndented = true }));
            }
            else { Console.WriteLine("Error: upload was not successful"); }

            //***************
            // Get voice list
            //***************

            //var voiceList = await txtomediaApi.Voicelist();
            //Console.WriteLine("** Voicelist");
            //Console.WriteLine(JsonSerializer.Serialize(voiceList.Content, new JsonSerializerOptions() { WriteIndented = true }));


            //******************
            // Get voice preview
            //******************

            //Console.WriteLine("** Voice Speech");
            //var voicePreview = txtomediaApi.Previewvoice(new CreateSpeechPreviewRequest()
            //{
            //    VoiceId = 86,
            //    Text = "Hello this is a voice preview generated by the TEXTOmedia API"
            //});
            //if (voicePreview.Result.StatusCode == HttpStatusCode.OK)
            //{
            //    var filename = voicePreview.Result.Content.Headers.ContentDisposition.FileName;
            //    using (FileStream filestream = File.Create($"D:\\{filename}"))
            //    {
            //        using (Stream stream = await voicePreview.Result.Content.ReadAsStreamAsync().ConfigureAwait(false))
            //        {
            //            await stream.CopyToAsync(filestream);
            //        }
            //    }
            //    voicePreview.Result.Content.Dispose();
            //}

            Console.WriteLine("press a key to exit");
            Console.ReadKey();
        }
    }
}