using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task Should_delete_parkingLot_with_status_204()
        {
            //Given
            string existId = await CreateNewParkingLot();

            //Then
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync($"{url}/{existId}");

            //Then
            Assert.Equal(HttpStatusCode.NoContent, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Should_get_parkingLots_with_status_200_given_pageIndex()
        {
            //Given
            await CreateNNewParkingLot(30);

            //Then
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{url}?pageIndex=1");

            //Then
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Should_return_bad_request_with_given_invalid_pageIndex()
        {
            //Given
            await CreateNNewParkingLot(30);

            //Then
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{url}?pageIndex=-1");

            //Then
            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Should_return_parkingLot_with_status_200_given_valid_id()
        {
            //Given
            string existId = await CreateNewParkingLot();

            //Then
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{url}/{existId}");

            //Then
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Should_return_parkingLot_with_status_404_given_invalid_id()
        {
            //Then
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{url}/wrongId");

            //Then
            Assert.Equal(HttpStatusCode.NotFound, responseMessage.StatusCode);
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

        private async Task CreateNNewParkingLot(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var parkingLotRequestDto = new ParkingLotRequestDto()
                {
                    Name = $"parking lot {num}",
                    Capacity = 10,
                    Location = "TS buildingA"
                };
                await _httpClient.PostAsJsonAsync(url, parkingLotRequestDto);
            }
        }
    }
}
