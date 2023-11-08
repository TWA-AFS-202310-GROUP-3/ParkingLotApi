using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_400_when_create_parking_lot_given_capacity_less_10()
        {
            //Given
            HttpClient httpClient = GetClient();
            ParkingLotDto parkingLotDto = new ParkingLotDto()
            {
                Name = "xianke",
                Capacity = 9,
                Location = "csgo"
            };
            //When
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("/Parkinglots", parkingLotDto);
            //Then
            Assert.Equal(HttpStatusCode.BadRequest, httpResponseMessage.StatusCode);
        }
    }
}
