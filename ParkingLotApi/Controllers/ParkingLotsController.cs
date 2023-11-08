using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService _parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            _parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotEntity>> AddParkingLot([FromBody] ParkingLotDto parkingLotDto)
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

        [HttpGet]
        public async Task<ActionResult<List<ParkingLotEntity>>> GetOnePageParkingLots([FromQuery] int pageIndex)
        {
            return await _parkingLotsService.GetOnePageParkingLots(pageIndex);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ParkingLotEntity>>> GetParkingLotById(string id)
        {
            var parkingLot = await _parkingLotsService.GetByIdAsync(id);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return Ok(parkingLot);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLotEntity>> UpdateCapacityAsync(string id, [FromBody] int capacity)
        {
            var updatedParkingLot = await _parkingLotsService.UpdateCapacity(id, capacity);
            if (updatedParkingLot == null)
            {
                return NotFound();
            }
            return Ok(updatedParkingLot);
        }
    }
}