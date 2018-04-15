using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using udemyDatingApp.Data;

namespace udemyDatingApp.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IWeatherForecastRepository _forecastRepository;

        public SampleDataController(DataContext dataContext, IWeatherForecastRepository forecastRepository)
        {
            this._forecastRepository = forecastRepository;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetWeatherForecasts()
        {
            var forecasts = await this._forecastRepository.GetWeatherForecasts();

            return Ok(forecasts);
        }

        
    }
}
