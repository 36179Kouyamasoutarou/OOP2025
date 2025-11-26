using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace TenkiApp.Model {
    public class WeatherService {
        private readonly HttpClient _http = new HttpClient();

        public async Task<WeatherResponse> GetWeatherAsync(double latitude, double longitude) {
            // 💡 修正: hourlyパラメータを追加しました
            string url = $"https://api.open-meteo.com/v1/forecast?" +
                          $"latitude={latitude}&longitude={longitude}" +
                          $"&current=temperature_2m,apparent_temperature,relative_humidity_2m,weather_code,wind_speed_10m,wind_direction_10m,precipitation" +
                          $"&hourly=temperature_2m,weather_code,precipitation_probability" + // <-- NEW
                          $"&daily=weather_code,temperature_2m_max,temperature_2m_min" +
                          $"&timezone=auto" +
                          $"&forecast_days=2" +
                          $"&temperature_unit=celsius" +
                          $"&wind_speed_unit=ms";

            try {
                var response = await _http.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine("--- API Response JSON ---");
                System.Diagnostics.Debug.WriteLine(json);

                return JsonSerializer.Deserialize<WeatherResponse>(json);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"!!! WeatherService Error !!!: {ex.Message}");
                throw;
            }
        }
    }
}