using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository _parkingLotsRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository) {
            _parkingLotsRepository = parkingLotsRepository;
        }
        public async Task<ParkingLotEntity> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException("The capacity should be no less than 10");
            }
            return await _parkingLotsRepository.CreateParkingLotAsync(parkingLotDto.ToEntity());
        }
    }
}
