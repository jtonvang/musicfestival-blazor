using MusicFestival.Blazor.Template.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MusicFestival.Blazor.Template.Json
{
    public class PageTypeConverter : JsonConverter<PageBaseViewModel>
    {        
        public override bool CanConvert(Type type)
        {
            return typeof(PageBaseViewModel).IsAssignableFrom(type);
        }

        public static readonly Dictionary<string, Type> TypeMap = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            { "LandingPage", typeof(LandingPageViewModel) },
            { "ArtistContainerPage", typeof(ArtistContainerPageViewModel) },
            { "ArtistDetailsPage", typeof(ArtistDetailsPageViewModel) },

        };

        public override PageBaseViewModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {     
            if (reader.TokenType == JsonTokenType.Null) return null;

            // Copy the current state from reader (it's a struct)
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var contentTypes = jsonObject.GetProperty("contentType").EnumerateArray();

            // Concrete type is the last of the passed types from Content API
            var concreteType = contentTypes.Last().GetString();

            if (!string.IsNullOrEmpty(concreteType) && TypeMap.TryGetValue(concreteType, out var targetType))
            {
                // New options object needed to prevent this converter being called again,
                // causing an infinite loop. 
                var nonLoopingOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new BlockTypeConverter() }
                };

                return JsonSerializer.Deserialize(ref readerAtStart, targetType, nonLoopingOptions) as PageBaseViewModel;
            }

            throw new NotSupportedException($"{concreteType ?? "<unknown>"} can not be deserialized");
        }


        /// <summary>
        /// We don't need serialization and so, the converter doesn't support it.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, PageBaseViewModel value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }


    }
}
