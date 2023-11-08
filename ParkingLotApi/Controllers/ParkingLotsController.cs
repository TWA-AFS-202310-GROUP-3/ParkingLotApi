﻿using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
