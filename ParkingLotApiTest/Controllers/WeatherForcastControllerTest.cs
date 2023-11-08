using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForcastControllerTest : TestBase
    {
        private HttpClient _httpClient;
        public WeatherForcastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        { 
            _httpClient = GetClient();
        }
        [Fact]
        public async Task Should_return_correctly_when_get_weather_forecast()
        {
            // 测试命令： dotnet test .\ParkingLotApiTest\
            // Given & When
            HttpResponseMessage response = await _httpClient.GetAsync("/WeatherForecast");
            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
