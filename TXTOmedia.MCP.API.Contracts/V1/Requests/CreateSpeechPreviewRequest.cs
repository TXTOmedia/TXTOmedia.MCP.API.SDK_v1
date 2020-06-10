namespace TXTOmedia.MCP.API.Contracts.V1.Requests
{
    /// <summary>
    /// Create Speech Preview Request
    /// </summary>
    public class CreateSpeechPreviewRequest
    {
        /// <summary>
        /// Text fragment will translated into a spoken voice 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// a Voice id is needed to select a certain voice for a language you can retrieve the the voiceid by a call to endpoit speech/voicelist to receive  a voicelist
        /// voiceid always start with a 'V' and have 3 digits
        /// </summary>
        public string  VoiceId  { get; set; }
    }
}
