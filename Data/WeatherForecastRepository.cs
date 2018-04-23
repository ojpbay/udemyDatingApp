using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemyDatingApp.Models;

namespace udemyDatingApp.Data
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly DataContext _dataContext;

        public WeatherForecastRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<WeatherForecast> GetWeatherForecast(int id)
        {
            return await this._dataContext.WeatherForecasts.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            return await this._dataContext.WeatherForecasts.ToListAsync();
        }
    }
}
