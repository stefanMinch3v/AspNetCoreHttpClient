namespace HttpClientTheRightWay.Services
{
    using Models;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    using static ApiConstants;

    public class WeatherForecastService : IWeatherForecastService
    {
        private const string BASE_URI = "http://api.openweathermap.org/data/2.5";
        private const string API_KEY = "964b58e662d8682af763ac343fa4423b";
        private readonly HttpClient client;

        public WeatherForecastService(HttpClient client)
        {
            client.DefaultRequestHeaders.Add(API_HEADERS_EXAMPLE, API_KEY);
            this.client = client;
        }

        public async Task<WeatherForecastModel> GetWeatherByCity(string cityName, CancellationToken cancellationToken)
        {
            var response = await this.client.GetAsync($"{BASE_URI}/weather?q={cityName}&appid={API_KEY}", cancellationToken);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<WeatherForecastModel>(responseStream);
        }
    }
}
