using Microsoft.EntityFrameworkCore;
using udemyDatingApp.Models;

namespace udemyDatingApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
