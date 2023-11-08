using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;
using System.Runtime.CompilerServices;

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
        public async Task<ActionResult<ParkingLotDto>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLot)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLot));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingLot(string id)
        {
            await _parkingLotsService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetAll([FromQuery]int pageIndex)
        {
            List<ParkingLot> parkingLots = await _parkingLotsService.GetAsync();
            int pageSize = 15;
            int countToBeSkip = pageSize * (pageIndex - 1);
            return Ok(parkingLots.Skip(countToBeSkip).Take(pageSize).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetParkingLotById(string id)
        {
            var parkingLot = await _parkingLotsService.GetByIdAsync(id);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return Ok(parkingLot);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLot>> UpdateCapacityById(string id, [FromBody] CapacityDto capacity)
        {
            var parkingLot = await _parkingLotsService.GetByIdAsync(id);
            if(parkingLot == null)
            {
                return NotFound();
            }
            parkingLot.Capacity = capacity.Capacity;
            return Ok(await _parkingLotsService.UpdateParkingLotAsync(id, parkingLot));
        }
    }
}