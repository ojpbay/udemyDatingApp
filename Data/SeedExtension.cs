using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemyDatingApp.Models;

namespace udemyDatingApp.Data
{
    public static class SeedExtension
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<DataContext>();

                SeedDatabase(context);
            }
            return host;
        }

        public static void SeedDatabase(DataContext context)
        {
            if (!context.WeatherForecasts.Any())
            {
                var forecasts = new List<WeatherForecast>
                {
                    new WeatherForecast { DateFormatted = "2018-04-15", Summary = "Mild", TemperatureC = 15 },
                    new WeatherForecast { DateFormatted = "2018-04-18", Summary = "Balmy", TemperatureC = 24 },
                    new WeatherForecast { DateFormatted = "2018-03-01", Summary = "Freezing", TemperatureC = -2 },
                    new WeatherForecast { DateFormatted = "2018-04-01", Summary = "Cool", TemperatureC = 6 },
                };

                context.WeatherForecasts.AddRange(forecasts);
                context.SaveChanges();
            }
        }
    }
}
