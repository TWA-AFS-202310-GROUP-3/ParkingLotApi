using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

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
        public async Task<ActionResult<ParkingLotEntity>> CreateParkingLost([FromBody] ParkingLotRequestDto parkingLotRequestDto)
        {
            return StatusCode(StatusCodes.Status201Created, await parkingService.AddParkingLot(parkingLotRequestDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingLost(string id)
        {
            await parkingService.DeleteParkingLot(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
