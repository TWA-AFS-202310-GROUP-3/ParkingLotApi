using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotControllerTest: TestBase
    {
        private HttpClient _httpClient;
        public ParkingLotControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = GetClient();

        }

        [Fact]
        public async Task Should_return_bad_request_when_given_invalid_capacity()
        {
            //Given
            ParkingLotDto parkingLotDto = new ParkingLotDto()
            {
                Name = "best park",
                Capacity = 9,
                Location = "TS buildingA"
            };

            //When
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync("/parkingLots", parkingLotDto);

            //Then
            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Should_return_bad_request_when_given_duplicate_name()
        {
            //Given
            ParkingLotDto parkingLotDto = new ParkingLotDto()
            {
                Name = "best park",
                Capacity = 10,
                Location = "TS buildingA"
            };

            //When
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync("/parkingLots", parkingLotDto);
            
            //Then
            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Should_return_created_parkingLot_with_statusCode_201()
        {
            //Given
            ParkingLotDto parkingLotDto = new ParkingLotDto()
            {
                Name = "best park",
                Capacity = 10,
                Location = "TS buildingA"
            };

            //When
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync("/parkingLots", parkingLotDto);
            
            //Then
            Assert.Equal(HttpStatusCode.Created, responseMessage.StatusCode);
        }
    }
}
