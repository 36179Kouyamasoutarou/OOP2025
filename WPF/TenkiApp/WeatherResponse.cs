using System.Text.Json.Serialization;

namespace TenkiApp.Model {
    public class WeatherResponse {
        [JsonPropertyName("current_weather")]
        public CurrentWeather Current { get; set; }

        public class CurrentWeather {
            [JsonPropertyName("temperature")]
            public double Temperature { get; set; }

            [JsonPropertyName("windspeed")]
            public double WindSpeed { get; set; }

            [JsonPropertyName("weathercode")]
            public int WeatherCode { get; set; }

            [JsonPropertyName("time")]
            public string Time { get; set; }
        }
    }
}
