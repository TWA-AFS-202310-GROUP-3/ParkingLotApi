using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_400_when_create_parking_lot_given_capacity_less_than_10()
        {
            ParkingLotDto parkingLotDtoWithCapacityLessThan10 = new ParkingLotDto()
            {
                Name = "Best Parking Lot",
                Capacity = 9,
                Location = "Chuangxin Building"
            };

            HttpClient httpClient = GetClient();
            // Given & When
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/ParkingLots", parkingLotDtoWithCapacityLessThan10);
            // Then
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
