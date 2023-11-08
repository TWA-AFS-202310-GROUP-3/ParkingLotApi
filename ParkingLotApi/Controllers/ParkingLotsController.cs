using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")] //Ĭ��ParkingLotsController��controllerǰ����ַ���·��
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService _parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService) //��ParkingLotsServiceע�빹�캯��
        {
            _parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            //try
            //{
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
            //}
            //catch (InvalidCapacityException ex)
            //{
            //    return BadRequest();
            //}

            //if (parkingLotDto.Capacity < 10)
            //{
            //    return BadRequest();
            //}
            // return null;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteParkingLotAsync(string id)
        {
            await _parkingLotsService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetOnePageAsync([FromQuery] int? pageIndex)
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
                return Ok(await _parkingLotsService.GetOnePageAsync((int)pageIndex));
            }
            else
            {
                return Ok(await _parkingLotsService.GetOnePageAsync((int)pageIndex));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetParkingLotByIdAsync(string id)
        {
            var parkingLot = await _parkingLotsService.GetByIdAsync(id);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return Ok(parkingLot);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> GetParkingLotByIdAsync(string id, int capacity)
        {
            var updatedParkingLot = await _parkingLotsService.UpdateParkingLotCapacityAsync(capacity, id);
            if (updatedParkingLot == null)
            {
                return NotFound();
            }
            return Ok(updatedParkingLot);
        }
    }
}