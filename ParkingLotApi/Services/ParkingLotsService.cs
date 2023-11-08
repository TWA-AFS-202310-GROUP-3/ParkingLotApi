using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        public async Task<ParkingLotDto> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException("The capacity should be no less than 10");
            }
            return null;
        }
    }
}
