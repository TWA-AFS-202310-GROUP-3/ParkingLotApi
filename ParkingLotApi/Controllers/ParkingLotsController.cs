using Microsoft.AspNetCore.Mvc;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")] //Ĭ��ParkingLotsController��controllerǰ����ַ���·��
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