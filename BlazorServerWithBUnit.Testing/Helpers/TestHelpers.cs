using System;
using System.Linq;
using BlazorServerWithBUnit.Data;

namespace BlazorServerWithBUnit.Testing.Helpers
{
    public static class TestHelpers
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static WeatherForecast[] ToForecast(this DateTime date)
        {
            var rng = new Random();
            var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = date.AddDays(index).Date,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .OrderBy(x => x.Summary).ToArray();
            return list;
        }
    }
}
