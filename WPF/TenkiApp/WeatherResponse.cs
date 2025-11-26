using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TenkiApp.Model {
    public class WeatherResponse {
        [JsonPropertyName("current")]
        public CurrentData Current { get; set; }

        [JsonPropertyName("daily")]
        public DailyData Daily { get; set; }

        [JsonPropertyName("hourly")] // 💡 NEW: 時間別データ
        public HourlyData Hourly { get; set; }

        public class CurrentData {
            [JsonPropertyName("time")]
            public string Time { get; set; }

            [JsonPropertyName("temperature_2m")]
            public double? Temperature { get; set; }

            [JsonPropertyName("apparent_temperature")]
            public double? ApparentTemperature { get; set; }

            [JsonPropertyName("relative_humidity_2m")]
            public int? Humidity { get; set; }

            [JsonPropertyName("weather_code")]
            public int? WeatherCode { get; set; }

            [JsonPropertyName("wind_speed_10m")]
            public double? WindSpeed { get; set; }

            [JsonPropertyName("wind_direction_10m")]
            public int? WindDirection { get; set; }

            [JsonPropertyName("precipitation")]
            public double? Precipitation { get; set; }
        }

        public class DailyData {
            [JsonPropertyName("time")]
            public List<string> Time { get; set; }

            [JsonPropertyName("weather_code")]
            public List<int> WeatherCode { get; set; }

            [JsonPropertyName("temperature_2m_max")]
            public List<double> TemperatureMax { get; set; }

            [JsonPropertyName("temperature_2m_min")]
            public List<double> TemperatureMin { get; set; }
        }

        // 💡 NEW: 時間別予報データ構造
        public class HourlyData {
            [JsonPropertyName("time")]
            public List<string> Time { get; set; }

            [JsonPropertyName("temperature_2m")]
            public List<double> Temperature { get; set; }

            [JsonPropertyName("weather_code")]
            public List<int> WeatherCode { get; set; }

            [JsonPropertyName("precipitation_probability")]
            public List<int> PrecipitationProbability { get; set; }
        }
    }
}