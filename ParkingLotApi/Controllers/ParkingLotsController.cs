using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Services;
using ParkingLotApiTest.Dtos;
using ParkingLotApiTest.Models;
using ParkingLotApi.Exceptions;

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
           
            try
            {
                return StatusCode(StatusCodes.Status201Created,await parkingService.AddParkingLot(parkingLotDto));
            }
            catch (InvalidCapacityException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
