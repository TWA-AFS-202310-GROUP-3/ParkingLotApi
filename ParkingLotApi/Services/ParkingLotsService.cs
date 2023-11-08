using ParkingLotApi.Exceptions;
using ParkingLotApi.Repositories;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
using ParkingLotApi.Utils;


namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotRepository parkingLotRepository = null;
        public ParkingLotsService(IParkingLotRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLotEntity> AddParkingLot(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await parkingLotRepository.createParkingLot(DataConverter.ConvertToParkingLotEntity(parkingLotDto));
        }
    }
}
