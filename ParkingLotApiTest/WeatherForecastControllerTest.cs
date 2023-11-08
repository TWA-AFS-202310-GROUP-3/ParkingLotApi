using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest
{
    public class WeatherForecastControllerTest
    {
        private HttpClient _httpClient;

        public WeatherForecastControllerTest()
        {
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task Should_return_correctly_when_get_weather_forecast()
        {
            //given & when
            HttpResponseMessage response = await _httpClient.GetAsync("/WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
