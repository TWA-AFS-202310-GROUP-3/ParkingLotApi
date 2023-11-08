using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
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
            try
            {
                return StatusCode(StatusCodes.Status201Created,  await _parkingLotsService.AddAsync(parkingLot));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}