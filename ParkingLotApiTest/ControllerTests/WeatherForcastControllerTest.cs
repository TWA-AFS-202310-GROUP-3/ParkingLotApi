using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.ControllerTests
{
    public class WeatherForcastControllerTest
    {
        private HttpClient _httpClient;
        public WeatherForcastControllerTest() 
        {
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateClient();
        }
        [Fact]
        public async Task Should_return_correctly_When_weatherForcast()
        {
            //given & when
            HttpResponseMessage response = await _httpClient.GetAsync("/WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
