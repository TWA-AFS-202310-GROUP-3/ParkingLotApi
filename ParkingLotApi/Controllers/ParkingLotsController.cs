using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")] //默认ParkingLotsController中controller前面的字符是路径
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService _parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService) //将ParkingLotsService注入构造函数
        {
            this._parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
            }
            catch (InvalidCapacityException ex)
            {
                return BadRequest();
            }
            //if (parkingLotDto.Capacity < 10)
            //{
            //    return BadRequest();
            //}
            //return null;
        }
    }
}