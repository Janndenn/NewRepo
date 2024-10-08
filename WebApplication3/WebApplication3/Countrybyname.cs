using System.Text.Json.Serialization;

namespace CountryApi.Models
{
    public class CountryByName
    {
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Capital { get; set; }

        public List<string> CallingCodes { get; set; }


        [JsonPropertyName("flags")]
        public Flag Flag { get; set; }

        public List<string> Timezones { get; set; }
    }


    public class Flag
    {

        [JsonPropertyName("png")]
        public string Png { get; set; }

        [JsonPropertyName("svg")]
        public string Svg { get; set; }
    }
}
