namespace HttpClientTheRightWay.Models
{
    using System.Text.Json.Serialization;

    public class WeatherForecastModel
    {
        [JsonPropertyName("coord")]
        public Location Coord { get; set; }

        [JsonPropertyName("weather")]
        public WeatherDescription[] Weather { get; set; }

        public class WeatherDescription
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("icon")]
            public string Icon { get; set; }
        }

        public class Location
        {
            [JsonPropertyName("lon")]
            public float Longitude { get; set; }

            [JsonPropertyName("lat")]
            public float Latitude { get; set; }
        }
    }
}
