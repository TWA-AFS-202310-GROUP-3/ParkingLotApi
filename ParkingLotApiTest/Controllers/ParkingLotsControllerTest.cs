using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Controllers;
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
        public async Task Should_return_400_when_create_parkinglot_given_capacity_less_than_10()
        {
            //given
            HttpClient httpClient = GetClient(); //每个test里的client可以不一样
            ParkingLotDto parkingLotWithCapacityLessThan10 = new ParkingLotDto() //parkinglot request
            {
                Name = "Best Park",
                Capacity = 9,
                Location = "TS Building A"
            };

            //when
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/parkinglots", parkingLotWithCapacityLessThan10);

            //then
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
