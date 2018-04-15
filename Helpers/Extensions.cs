using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using udemyDatingApp.Data;
using udemyDatingApp.Models;

namespace udemyDatingApp.Helpers
{
    public static class Extensions
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

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);

            // these probably aren't necessary
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        private static void SeedDatabase(DataContext context)
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
