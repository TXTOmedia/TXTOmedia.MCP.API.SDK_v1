using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TXTOmedia.MCP.API.Contracts.V1.Responses
{
    public partial class VoiceFactoryVoicesResponse
    {
        [JsonProperty("Langs")]
        public List<Lang> Langs { get; set; }
    }

    public partial class Lang
    {
        [JsonProperty("langid")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string LangLang { get; set; }

        [JsonProperty("languages")]
        public List<Language> Languages { get; set; }
    }

    public partial class Language
    {
        [JsonProperty("voiceid")]
        public string Id { get; set; }

        [JsonProperty("Locale")]
        public string Locale { get; set; }

        [JsonProperty("Language")]
        public string LanguageLanguage { get; set; }

        [JsonProperty("Gender")]
        public Gender Gender { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender { Female, Male };

    public partial class VoiceFactoryVoicesResponse
    {
        public static VoiceFactoryVoicesResponse FromJson(string json) => JsonConvert.DeserializeObject<VoiceFactoryVoicesResponse>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this VoiceFactoryVoicesResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                GenderConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class GenderConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Gender) || t == typeof(Gender?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Female":
                    return Gender.Female;
                case "Male":
                    return Gender.Male;
            }
            throw new Exception("Cannot unmarshal type Gender");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Gender)untypedValue;
            switch (value)
            {
                case Gender.Female:
                    serializer.Serialize(writer, "Female");
                    return;
                case Gender.Male:
                    serializer.Serialize(writer, "Male");
                    return;
            }
            throw new Exception("Cannot marshal type Gender");
        }

        public static readonly GenderConverter Singleton = new GenderConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
