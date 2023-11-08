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
using System.Net.Http.Json;
using ParkingLotApi.Models;

namespace ParkingLotApiTest.ControllerTests
{
    public class ParkingLotsControllerTest : TestBase
    {

        public ParkingLotsControllerTest (WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Should_return_400_When_weatherForcast()
        {
            //given & when
            HttpClient _httpClient = GetClient();
            ParkingLotDto parkingLotWithLessThan10 = new ParkingLotDto()
            {
                Name = "ParkingLot1",
                Capacity = 1,
                Location = "Chengfu LU"
            };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/ParkingLots", parkingLotWithLessThan10);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
