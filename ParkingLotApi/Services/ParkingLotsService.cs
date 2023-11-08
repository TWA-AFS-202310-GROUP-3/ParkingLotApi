using ParkingLotApi.Exceptions;
using ParkingLotApiTest.Dtos;
using ParkingLotApiTest.Models;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        public async Task<ParkingLotEntity> AddParkingLot(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            else return new ParkingLotEntity();
        }
    }
}
