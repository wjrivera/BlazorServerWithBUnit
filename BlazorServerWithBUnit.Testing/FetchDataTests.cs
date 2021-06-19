using System;
using BlazorServerWithBUnit.Data;
using BlazorServerWithBUnit.Pages;
using BlazorServerWithBUnit.Testing.Helpers;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace BlazorServerWithBUnit.Testing
{
    public class FetchDataTests
    {
        [Fact]
        public void TestIncrementCounterButton()
        {
            var data = DateTime.Now.ToForecast();

            var mock = new Mock<IWeatherForecastService>();
            mock.Setup(x => x.GetForecastAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(data);
            
            using var ctx = new TestContext();
            ctx.Services.AddSingleton(mock.Object);
            var cut = ctx.RenderComponent<FetchData>();

            var initialComponentRender =
                $@"<h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from a service.</p>
                <table class={"table"}>
                    <thead>
                        <tr>
                          <th>Date</th>
                          <th>Temp. (C)</th>
                          <th>Temp. (F)</th>
                          <th>Summary</th>
                        </tr>
                      </thead>
                      <tbody>
                      ";
            
            foreach (var row in data)
            {
                initialComponentRender += $@"<tr>
                          <td>{row.Date:d}</td>
                          <td>{row.TemperatureC}</td>
                          <td>{row.TemperatureF}</td>
                          <td>{row.Summary}</td>
                        </tr>";
            }

            initialComponentRender += @"</tbody>
                    </table>";

            cut.MarkupMatches(initialComponentRender);
        }
    }
}
