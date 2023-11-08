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
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLost([FromBody] ParkingLotRequestDto parkingLotRequestDto)
        {
            return StatusCode(StatusCodes.Status201Created, await parkingService.AddParkingLot(parkingLotRequestDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingLost(string id)
        {
            await parkingService.DeleteParkingLot(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet]
        public async Task<ActionResult> GetParkingLosts(int pageIndex = 0)
        {
            if (pageIndex < 0)
            {
                return BadRequest();
            }
            return StatusCode(StatusCodes.Status200OK, await parkingService.GetParkLots(pageIndex));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLotDto>> GetParkingLost(string id)
        {
            return StatusCode(StatusCodes.Status200OK, await parkingService.GetParkLot(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLotDto>> PutParkingLost(string id, ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status200OK, await parkingService.UpdateParkLot(id, parkingLotDto));
        }


    }
}
