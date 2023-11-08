using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        public async Task<ParkingLotDto> AddAsync(ParkingLotDto parkingLotDto) //Task<返回值的类型>
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            return null;
        }
    }
}
