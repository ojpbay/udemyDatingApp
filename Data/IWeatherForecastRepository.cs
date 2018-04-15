using System.Collections.Generic;
using System.Threading.Tasks;
using udemyDatingApp.Models;

namespace udemyDatingApp.Data
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecasts();
    }
}