using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ParkingLotApiTest;

namespace ParkingLotApiTest.ControllerTests
{
    public class WeatherForcastControllerTest : TestBase
    {

        public WeatherForcastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }
        [Fact]
        public async Task Should_return_correctly_When_weatherForcast()
        {
            //given & when
            HttpClient _httpClient = GetClient();
            HttpResponseMessage response = await _httpClient.GetAsync("/WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
