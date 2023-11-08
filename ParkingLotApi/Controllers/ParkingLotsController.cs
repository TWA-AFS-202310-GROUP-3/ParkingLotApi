using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Services;
using ParkingLotApiTest.Dtos;
using ParkingLotApiTest.Models;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {

        private readonly ParkingLotsService parkingService = null;
        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            this.parkingService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotEntity>> CreateParkingLost([FromBody] ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                return BadRequest();
            }
            return null;
        }
    }
}
