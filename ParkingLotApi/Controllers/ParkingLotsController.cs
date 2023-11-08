﻿using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
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
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.CreateAsync(parkingLotDto));
            }
            catch (ArgumentException exception)
            {
                return BadRequest();
            }
        }
    }
}
