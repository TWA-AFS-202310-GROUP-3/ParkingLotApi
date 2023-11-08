using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private ParkingLotService parkingLotService;

        public ParkingLotsController(ParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            //try
            //{
            return StatusCode(StatusCodes.Status201Created, await parkingLotService.CreateAsync(parkingLotDto));
            //}
            //catch (InvalidCapacityException ex)
            //{
            //    return BadRequest();
            //}
        }

        [HttpDelete("id")]
        public async Task<ActionResult<ParkingLotDto>> DeleteParkingLotAsync(string id)
        {
            await parkingLotService.DeleteParkingLot(id);
            return new NoContentResult();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotsByPageInfoAsync(int pageIndex)
        {
            return await parkingLotService.GetParkingLotByPageInfo(pageIndex);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetParkingLotByIdAsync(string id)
        {
            return await parkingLotService.GetParkingLotById(id);
        }
    }
}
