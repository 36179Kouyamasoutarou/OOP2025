using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TenkiApp.Model {
    public class WeatherService {
        private readonly HttpClient _http = new HttpClient();

        public async Task<WeatherResponse> GetWeatherAsync(double latitude, double longitude) {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";
            return await _http.GetFromJsonAsync<WeatherResponse>(url);
        }
    }
}
