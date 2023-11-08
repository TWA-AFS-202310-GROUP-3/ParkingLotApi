using Microsoft.AspNetCore.Mvc.Testing;
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
            //Given & When
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("/WeatherForecast");
            //Then
            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
        }
    }
}
