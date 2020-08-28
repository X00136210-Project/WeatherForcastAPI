using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForcastAPI.Models
{
    //single db table
    public class Forcast
    {
        [Key]
        public String ID { get; set; }
        public String Name { get; set; }
        public String Condition { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public String WindDir { get; set; }
        public int WindSpeed { get; set; }
        public String Outlook { get; set; }
    }
}
