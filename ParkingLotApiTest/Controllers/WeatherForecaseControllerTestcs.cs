using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecaseControllerTestcs
    {
        private HttpClient _httpClient;
        public WeatherForecaseControllerTestcs()
        {
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateClient();

        }

        [Fact]
        public async Task Should_return_correctly_when_get_weather_forecase()
        {
            //Given
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("/WeatherForecast");
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }
    }
}
