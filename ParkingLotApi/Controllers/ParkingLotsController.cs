using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {        
        private readonly ParkingLotsService _parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            this._parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLotAysnc([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.CreateAsync(parkingLotDto));
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> Delete(string name)
        {
            await _parkingLotsService.DeleteAsync(name);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ParkingLotDto>> Get(int? pageSize, int? pageIndex)
        {
            if (pageSize != null && pageIndex != null)
            {
                return Ok(await _parkingLotsService.GetPage((int)pageSize, pageIndex));
            }
            return Ok(await _parkingLotsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLotDto>> GetById(string id)
        {
            var parkingLot = await _parkingLotsService.GetById(id);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return Ok(parkingLot);
        }
    }
}
