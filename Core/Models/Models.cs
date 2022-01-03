namespace Our.Umbraco.Hubspot.Models
{
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class HubspotForms
    {
        public static List<HubspotForm> Forms { get; set; }
    }

    public partial class HubspotForm
    {
        [JsonProperty("portalId")]
        public long PortalId { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("formFieldGroups")]
        public List<FormFieldGroup> FormFieldGroups { get; set; }
    }

    public partial class FormFieldGroup
    {
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
    }

    public partial class Field
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public partial class HubspotForms
    {
        public static List<HubspotForm> FromJson(string json) => JsonConvert.DeserializeObject<List<HubspotForm>>(json, Our.Umbraco.Hubspot.Models.Converter.Settings);
    }

    public partial class HubspotForm
    {
        public static HubspotForm FromJson(string json) => JsonConvert.DeserializeObject<HubspotForm>(json, Our.Umbraco.Hubspot.Models.Converter.Settings);
    }


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
