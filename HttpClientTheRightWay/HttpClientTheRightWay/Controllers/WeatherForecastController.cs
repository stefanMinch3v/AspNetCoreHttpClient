namespace HttpClientTheRightWay.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using Services;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService weatherService;
        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(
            IWeatherForecastService weatherService,
            ILogger<WeatherForecastController> logger)
            => (this.weatherService, this.logger) = (weatherService, logger);

        [HttpGet]
        public async Task<WeatherForecastModel> Get(string cityName, CancellationToken cancellationToken)
        {
            try
            {
                return await weatherService.GetWeatherByCity(cityName ??= "London", cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                this.logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
