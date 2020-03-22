namespace HttpClientTheRightWay.Services
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IWeatherForecastService
    {
        Task<WeatherForecastModel> GetWeatherByCity(string cityName, CancellationToken cancellationToken);
    }
}
