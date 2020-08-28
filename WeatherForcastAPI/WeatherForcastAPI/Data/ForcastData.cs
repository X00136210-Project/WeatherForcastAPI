using Microsoft.AspNetCore.Builder; //IApplicationBuilder
using Microsoft.Extensions.DependencyInjection;//<IServiceScopeFactory
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForcastAPI.Models; //Forcast class from Models

namespace WeatherForcastAPI.Data
{
    public class ForcastData
    {
        //initializer - build the app object
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                //handle to DB context
                var context = serviceScope.ServiceProvider.GetService<WeatherForcastContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                //look for any forcasts
                if (context.Forcasts != null && context.Forcasts.Any())
                    return; //DB has already been seeded

                
                //get WeatherForcast context and save it
                var forcasts = GetForcasts().ToArray();//getForcasts takes no context as an argument
                context.Forcasts.AddRange(forcasts);
                context.SaveChanges();

            }
        }

        //list of cities and weather forcasts (Forcast Models)
        public static List<Forcast> GetForcasts()
        {
            List<Forcast> forcasts = new List<Forcast>()
            {
                new Forcast {ID="1", Name="Dublin",
                        Condition="Sunny",
                        MaxTemp=25,
                        MinTemp=15,
                        WindDir="NW",
                        WindSpeed=12,
                        Outlook="High temps with gusty conditions to accomodate for the heat"},
                new Forcast {ID="2", Name="New York",
                        Condition="Rainy",
                        MaxTemp=15,
                        MinTemp=7,
                        WindDir="E",
                        WindSpeed=16,
                        Outlook="Windy and raining with semi-low temps"},
                new Forcast {ID="3", Name="Glasgow",
                        Condition="Snow",
                        MaxTemp=9,
                        MinTemp=-1,
                        WindDir="NE",
                        WindSpeed=19,
                        Outlook="NE bringing snow along with sub-zero temps"},
                new Forcast {ID="4", Name="Moscow",
                        Condition="Blizzard",
                        MaxTemp=-5,
                        MinTemp=-10,
                        WindDir="NW",
                        WindSpeed=110,
                        Outlook="Exteme conditions as blizzards come and low temps kick in with high wind speeds"},
            };

            //return list of forcasts
            return forcasts;
        }
    }
}
