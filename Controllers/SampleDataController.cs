using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using udemyDatingApp.Data;
using udemyDatingApp.Models;

namespace udemyDatingApp.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly DataContext _dataContext;

        public SampleDataController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }       

        [HttpGet]
        public IActionResult GetWeatherForecasts()
        {
            var forecasts = _dataContext.WeatherForecasts.ToList();

            return Ok(forecasts);
        }

        
    }
}
