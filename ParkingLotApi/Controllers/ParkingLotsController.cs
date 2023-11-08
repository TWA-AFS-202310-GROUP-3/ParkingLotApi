using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
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
            _parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLot([FromBody] ParkingLotDto parkingLotDto)
        {
           /* try
            {*/
               // return  Created("", await _parkingLotsService.AddAsync(parkingLotDto));
                return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
           /* } catch (InvalidCapacityException ex)
            {
                return BadRequest(ex.Message);
            }*/
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveParkingLot(string id)
        {
            var isRemoved = await _parkingLotsService.RemoveAsync(id);
            if (isRemoved) 
            { 
                return NoContent();
            }
            return NotFound();
        }
    }
}