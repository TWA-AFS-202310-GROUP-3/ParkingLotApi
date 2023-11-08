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

        public async Task<ParkingLotDto> AddParkingLot(ParkingLotRequestDto parkingLotRequestDto)
        {
            if (parkingLotRequestDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            ParkingLotDto parkingLotDto = DataConverter.ConvertToParkingLotDto(await parkingLotRepository.CreateParkingLot(DataConverter.ConvertRequestToParkingLotEntity(parkingLotRequestDto)));

            return parkingLotDto;
        }

        public async Task DeleteParkingLot(string id)
        {
            await parkingLotRepository.DeleteParkingLot(id);
        }
    }
}
