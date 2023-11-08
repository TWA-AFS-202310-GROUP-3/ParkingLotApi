using Microsoft.AspNetCore.Mvc;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")] //默认ParkingLotsController中controller前面的字符是路径
    public class ParkingLotsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLot([FromBody] ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                return BadRequest();
            }
            return null;
        }
    }
}