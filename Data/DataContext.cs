using Microsoft.EntityFrameworkCore;
using udemyDatingApp.Models;

namespace udemyDatingApp.Data
{
    public class DataContext : DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
