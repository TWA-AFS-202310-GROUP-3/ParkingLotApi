using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ParkingLotApi.Dtos;
using System.Net.Http.Json;

namespace ParkingLotApiTest.Controller
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_400_when_create_parking_lot_given_capacity_less_than_10()
        {
            //given

            ParkingLotDto parkingLotDtoWithCapacityLessThan10 = new ParkingLotDto()
            {
                Name = "Chuangxin parkinglot",
                Capacity = 9,
                Location = "tshinghua tech park"
            };

            HttpClient httpClient = GetClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/Parkinglots", parkingLotDtoWithCapacityLessThan10);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
