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
            ParkingLotEntity parkingLotEntity = await parkingLotRepository.CreateParkingLot(DataConverter.ConvertRequestToParkingLotEntity(parkingLotRequestDto));

            if (parkingLotEntity == null)
            {
                throw new DuplicateNameException();
            }

            return DataConverter.ConvertToParkingLotDto(parkingLotEntity);
        }

        public async Task DeleteParkingLot(string id)
        {
            await parkingLotRepository.DeleteParkingLot(id);
        }

        public async Task<List<ParkingLotDto>?> GetParkLots(int pageIndex)
        {
            int skipItems = (pageIndex - 1) * 15;
            List<ParkingLotEntity> parkingLotEntities = await parkingLotRepository.GetParkingLots();
            
            return parkingLotEntities.Skip(skipItems).Take(15).Select(entity => DataConverter.ConvertToParkingLotDto(entity)).ToList();
        }

        public async Task<ParkingLotDto> GetParkLot(string id)
        {
            ParkingLotDto parkingLotDto = DataConverter.ConvertToParkingLotDto(await parkingLotRepository.GetParkingLot(id));
            return parkingLotDto;
        }

        public async Task<ParkingLotDto> UpdateParkLot(string id, ParkingLotDto parkingLotDto)
        {
            await parkingLotRepository.UpdateParkingLot(id, DataConverter.ConvertToParkingLotEntity(parkingLotDto));
            return await GetParkLot(id);
        }
    }
}
