
using WeatherForcastAPI.Models; //models folder data
using Microsoft.EntityFrameworkCore; //DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForcastAPI.Data
{
    public class WeatherForcastContext : DbContext
    {
        public WeatherForcastContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Forcast> Forcasts { get; set; } //ref to Forcast class in Models
    }
}
