using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
using System.Net;
using System.Net.Http.Json;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotControllerTest: TestBase
    {
        private HttpClient _httpClient;
        private readonly string url = "/parkingLots";

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
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url, parkingLotDto);

            //Then
            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);
        }

        //[Fact]
        //public async Task Should_return_bad_request_when_given_duplicate_name()
        //{
        //    //Given
        //    ParkingLotDto parkingLotDto = new ParkingLotDto()
        //    {
        //        Name = "best park",
        //        Capacity = 10,
        //        Location = "TS buildingA"
        //    };

        //    //When
        //    HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync("/parkingLots", parkingLotDto);
            
        //    //Then
        //    Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);
        //}

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
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url, parkingLotDto);
            
            //Then
            Assert.Equal(HttpStatusCode.Created, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Should_delete_parking_with_status_204()
        {
            //Given
            string existId = await CreateNewParkingLot();

            //Then
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync($"{url}/{existId}");

            //Then
            Assert.Equal(HttpStatusCode.NoContent, responseMessage.StatusCode);
        }

        private async Task<string> CreateNewParkingLot()
        {
            ParkingLotRequestDto parkingLotRequestDto = new ParkingLotRequestDto()
            {
                Name = "best park",
                Capacity = 10,
                Location = "TS buildingA"
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url, parkingLotRequestDto);
            ParkingLotDto? parkingLotDto = await responseMessage.Content.ReadFromJsonAsync<ParkingLotDto>();
            return parkingLotDto?.Id;
        }
    }
}
