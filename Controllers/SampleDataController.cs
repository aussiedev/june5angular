using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace june5angular.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Countries = new[]
        {
            "Australia", "India", "USA", "UK", "Canada", "Germany", "Japan"
        };


        private static string[] Cities = new[]
        {
            "Sydney", "Ahmedabad", "Chicago", "London", "Toronto", "Berlin", "Tokyo"
        };


        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 8).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<string> GetKeyCountries()
        {
            return Countries.AsEnumerable<string>();
        }

        /// <summary>
        /// Returns the list of the cities
        /// </summary>
        /// <returns>City List</returns>
        [HttpGet("[action]")]
        public IEnumerable<string> GetCities()
        {
            return Cities.AsEnumerable<string>();
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
